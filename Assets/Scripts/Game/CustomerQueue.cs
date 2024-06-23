using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
	public List<GameObject> queue = new List<GameObject>();
	public List<GameObject> leaving = new List<GameObject>();
	public float minimum_distance = 5;
	public Transform MoveTo;
	public Transform MoveFrom;
	public Transform Exit;
	public Global.Event CustomerFinished;
    void UpdateQueue(List<GameObject> list, Transform to)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].GetComponent<CustomerLogic>() == null) continue;
			Vector2.MoveTowards(list[i].transform.position, to.position - new Vector3(0, minimum_distance * i), 1);
		}
	}

	public void SpawnCustomers(int count)
	{
		var c = GameObject.FindGameObjectWithTag(Global.CUSTOMER_POOL_GROUP).transform;
		if (c.childCount < count) return;
		for (int i = 0; i < count; i++)
		{

		}
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
		leaving.Insert(0, q);
	}
}
