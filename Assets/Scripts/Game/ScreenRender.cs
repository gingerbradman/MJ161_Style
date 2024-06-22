using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderedObject : MonoBehaviour
{
    public GameObject renderObject;

	public virtual void Awake()
	{
		renderObject.transform.SetParent(GameObject.FindGameObjectWithTag(Global.CANVAS_GROUP).transform);
	}

	public virtual void Update()
	{
		renderObject.transform.position = transform.position;
	}
}
