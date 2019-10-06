﻿namespace Mapbox.Examples
{
	using UnityEngine;

	public class CameraBillboard180 : MonoBehaviour
	{
		public Camera _camera;

		public void Start()
		{
			_camera = Camera.main;
		}

		void Update()
		{
			transform.LookAt(transform.position + _camera.transform.rotation * -Vector3.forward, _camera.transform.rotation * Vector3.up);
		}
	}
}