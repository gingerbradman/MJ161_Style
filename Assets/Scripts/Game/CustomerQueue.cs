using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
	public List<GameObject> queue = new List<GameObject>();
	public List<GameObject> leaving = new List<GameObject>();
	public float minimum_distance = 500;
	public Transform MoveTo;
	public Transform MoveFrom;
	public Transform Exit;
	public float CustomerSpeed = 50f;
	public static Action<GameObject> CustomerFinished;
	public enum QueueType
	{
		CUSTOMER,
		VENDOR
	};

	public QueueType queueType;

	void Awake()
	{
		CustomerFinished += OnCustomerFinished;
	}

	NPCLogic GetNPCLogic(GameObject obj) {
		if (queueType == QueueType.CUSTOMER) return obj.GetComponent<CustomerLogic>();
		return obj.GetComponent<VendorLogic>();
	}

    void UpdateQueue(List<GameObject> list, Transform to)
	{
		for (int i = 0; i < list.Count; i++)
		{
			var l = GetNPCLogic(list[i]);
			if (l == null) continue;
			list[i].transform.position = Vector2.MoveTowards(list[i].transform.position, to.position + new Vector3(0, minimum_distance * i), CustomerSpeed * Time.deltaTime);
			if (Vector2.Distance(list[i].transform.position, to.position) < 1) {CustomerReachedDestination(list[i]);}
		}
	}

	public void SpawnCustomers(int count)
	{
		for (int i = 0; i < count; i++)
		{
			GameObject g;
			if (queueType == QueueType.CUSTOMER)
			{
				g = GameManager.Instance.CustomerPool.GetObject(transform);
			}
			else
			{
				g = GameManager.Instance.VendorPool.GetObject(transform);
			}
			g.transform.position = MoveFrom.position + new Vector3(0, minimum_distance * queue.Count);
			queue.Add(g);
		}
	}

	void CustomerReachedDestination(GameObject obj)
	{

		var l = GetNPCLogic(obj);
		if (queue.Contains(obj) && l.GetTimer().isPaused == true)
		{
			l.StartWaiting();
		}
		else if (leaving.Contains(obj))
		{
			leaving.Remove(obj);
			if (queueType == QueueType.CUSTOMER)
			{
				GameManager.Instance.CustomerPool.ReturnObject(obj);
			}
			else
			{
				GameManager.Instance.VendorPool.ReturnObject(obj);
			}
		}
	}

	void Update()
	{
		if (queue.Count > 0 && MoveTo.position.y - queue[0].transform.position.y < 1) UpdateQueue(queue, MoveTo);
		if (leaving.Count > 0 && Exit.position.y - leaving[0].transform.position.y < 1) UpdateQueue(leaving, Exit);
		if (queueType == QueueType.VENDOR && queue.Count < 5) SpawnCustomers(1);
	}

	void OnCustomerFinished(GameObject gameObject)
	{
		if (queue.Count == 0 || gameObject != queue[0]) return;
		var q = queue[0];
		queue.Remove(q);
		leaving.Add(q);
	}
}
