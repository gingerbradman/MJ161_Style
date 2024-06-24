using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public interface IPooled
{
	void Reset();
}

public class NPCPool : MonoBehaviour
{
	public int MaximumPoolCount;
	public int MinimumPoolCount;
	public GameObject ObjectToPool;

	void Awake()
	{
		if (ObjectToPool == null) return;
		for (int i = 0; i < MaximumPoolCount; i++)
		{
			var g = Instantiate(ObjectToPool,this.transform);
			g.SetActive(false);
		}
	}

	public GameObject GetObject(Transform attachTo)
	{
		GameObject g;
		if (transform.childCount > 0) {g = transform.GetChild(0).gameObject;}
		else g = Instantiate(ObjectToPool);
		g.SetActive(true);
		g.transform.SetParent(attachTo);
		return g;
	}

	public void ReturnObject(GameObject obj)
	{
		{
			obj.transform.SetParent(this.transform);
			foreach (var p in obj.GetComponents<IPooled>()) p.Reset();
			obj.SetActive(false);
		}
	}

	void Update()
	{
		if (ObjectToPool == null) return;
		if (transform.childCount > 0 && transform.childCount > MaximumPoolCount)
		{
			Destroy(transform.GetChild(0));
		}
		else if (transform.childCount < MinimumPoolCount)
		{
			for (int i = 0; i < MinimumPoolCount - transform.childCount; i++)
			{
				var g = Instantiate(ObjectToPool,this.transform);
				g.SetActive(false);
			}
		}
	}
	
}
