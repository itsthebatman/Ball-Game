using UnityEngine;
using System;
using System.Collections;

public class FloatBehaviour : MonoBehaviour {
	float originalX;
	void Start()
	{
		this.originalX = this.transform.position.x;
	}

	void Update()
	{
		transform.position = new Vector3 (originalX + ((float)Math.Sin (Time.time*2) *2),transform.position.y,
			transform.position.z);
	}
}
