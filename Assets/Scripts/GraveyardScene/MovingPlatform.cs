﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime);

		if (transform.position.y < 0) {
			GameObject.Destroy (gameObject);
		}
	}
}
