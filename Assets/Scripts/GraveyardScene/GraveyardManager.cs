using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardManager : MonoBehaviour {
	private float countdown = 2f;
	private float xMax = 7f; 
	private float xMin = -7f;
	private Vector2 spawnPoint;

	public GameObject platform;

	void Update () {
		CreatePlatform ();
	}
		
	void CreatePlatform()
	{
		Quaternion q = Quaternion.identity;
		countdown -= Time.deltaTime;

		if (countdown <= 0)
		{
			ChangeSpawnPoint ();
			Instantiate (platform, spawnPoint, q);
			countdown = 2f;
		}
	}

	void ChangeSpawnPoint()
	{
		spawnPoint = new Vector2(Random.Range(xMin, xMax), 6);
	}

}
