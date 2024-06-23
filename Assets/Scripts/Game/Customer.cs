using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Customer : NPC
{
	const float MINIMUM_PATIENT_TIME = 10;
	const float MAXIMUM_PATIENT_TIME = 30;
	public Product WantedProduct;
	public float PatientTime
	{
		get => Random.Range(MINIMUM_PATIENT_TIME, MAXIMUM_PATIENT_TIME);
	}
}
