using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	public static Global.Event CustomerFinished;

	void Awake()
	{
		CustomerFinished += OnCustomerFinished;
	}
    void UpdateQueue(List<GameObject> list, Transform to)
	{
		for (int i = 0; i < list.Count; i++)
		{
			var l = list[i].GetComponent<CustomerLogic>();
			if (l == null) continue;
			list[i].transform.position = Vector2.MoveTowards(list[i].transform.position, to.position + new Vector3(0, minimum_distance * i), CustomerSpeed * Time.deltaTime);
			if (Vector2.Distance(list[i].transform.position, to.position) < 1) {CustomerReachedDestination(list[i]);}
		}
	}

	void Start()
	{
		SpawnCustomers(5);
	}

	public void SpawnCustomers(int count)
	{
		for (int i = 0; i < count; i++)
		{
			var g = GameManager.Instance.CustomerPool.GetObject(transform);
			g.transform.position = MoveFrom.position + new Vector3(0, minimum_distance * i);
			queue.Add(g);
		}
	}

	void CustomerReachedDestination(GameObject obj)
	{
		if (queue.Contains(obj) && obj.GetComponent<CustomerLogic>().WaitTimer.isPaused == true) {obj.GetComponent<CustomerLogic>().StartWaiting();}
		else if (leaving.Contains(obj)) {leaving.Remove(obj); GameManager.Instance.CustomerPool.ReturnObject(obj);}
	}

	void Update()
	{
		if (queue.Count > 0 && MoveTo.position.y - queue[0].transform.position.y < 1) UpdateQueue(queue, MoveTo);
		if (leaving.Count > 0 && Exit.position.y - leaving[0].transform.position.y < 1) UpdateQueue(leaving, Exit);
	}

	void OnCustomerFinished()
	{
		if (queue.Count == 0) return;
		var q = queue[0];
		queue.Remove(q);
		leaving.Add(q);
	}
}
