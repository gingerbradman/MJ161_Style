using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraMoveZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Vector2 MoveAmount;
	[SerializeField] float MoveSpeed = .01f;
	[SerializeField] Canvas canvas;

	void Update()
	{
		Vector3 t = (MoveAmount * canvas.gameObject.GetComponent<RectTransform>().sizeDelta / 2);
		transform.position = canvas.transform.position + t;
	}

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