using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	[SerializeField] float CAM_LIMIT_UP;
	[SerializeField] float CAM_LIMIT_DOWN;
	[SerializeField] float CAM_LIMIT_RIGHT;
	[SerializeField] float CAM_LIMIT_LEFT;
	Camera mainCam;
	public delegate void CameraDelegate(Vector2 vector2);
	public static CameraDelegate MoveCameraInDirection;
    void Start()
    {
        mainCam = GetComponent<Camera>();
		if (!mainCam)
		{
			mainCam = gameObject.AddComponent<Camera>();
		}
		mainCam.tag = "MainCamera";
		MoveCameraInDirection += MoveCamera;
    }

	void MoveCamera(Vector2 vector)
	{
		var vec3 = new Vector3(vector.x, vector.y, 0);
		var pos = transform.position + vec3;
		transform.position = new Vector3(Mathf.Clamp(pos.x, CAM_LIMIT_LEFT, CAM_LIMIT_RIGHT), Mathf.Clamp(pos.y, CAM_LIMIT_DOWN, CAM_LIMIT_UP), transform.position.z);
	}
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, CAM_LIMIT_LEFT, CAM_LIMIT_RIGHT), Mathf.Clamp(transform.position.y, CAM_LIMIT_DOWN, CAM_LIMIT_UP), transform.position.z);
    }
}
