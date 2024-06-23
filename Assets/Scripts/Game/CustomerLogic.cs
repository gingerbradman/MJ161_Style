using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerLogic : RenderedObject, IPooled
{
	public Customer customer;
	public void Reset()
	{
		customer = null;
		renderObject.transform.SetParent(this.transform);
	}
}
