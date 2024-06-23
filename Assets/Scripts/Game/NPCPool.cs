using System;
using System.Linq.Expressions;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public interface IPooled
{
	void Reset();
}

public class NPCPool : Singleton<NPCPool>
{
	public int MaximumPoolCount;
	public int MinimumPoolCount;
	public GameObject ObjectToPool;

	protected override void OnAwake()
	{
		for (int i = 0; i < MaximumPoolCount; i++)
		{
			var g = Instantiate(ObjectToPool,this.transform);
			g.SetActive(false);
		}
	}

	public GameObject GetObject()
	{
		GameObject g;
		if (transform.childCount > 0)
		{
			g = transform.GetChild(0).gameObject;
		}
		g = Instantiate(ObjectToPool);
		g.SetActive(true);
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
