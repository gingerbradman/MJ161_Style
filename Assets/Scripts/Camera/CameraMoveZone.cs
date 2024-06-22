using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using	 UnityEngine.EventSystems;

public class CameraMoveZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Vector2 MoveAmount;
	[SerializeField] float MoveSpeed = .01f;

	public void OnPointerEnter(PointerEventData eventData)
	{
		StartCoroutine("MoveCamera");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		StopCoroutine("MoveCamera");
	}

	IEnumerator MoveCamera()
	{
		while (true)
		{
			yield return new WaitForSeconds(MoveSpeed);
			MainCamera.MoveCameraInDirection?.Invoke(MoveAmount);
		}
	}
}