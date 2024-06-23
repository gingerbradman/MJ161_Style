using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MachineBase : ScriptableObject
{
    public List<ItemMaterial> materialsRequired;
	public Product product;
	public float ProductionTime = 3f;
	public Sprite sprite;
	public Transform location;
}
