using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JungleManager: MonoBehaviour {
	private float countdown = 2f;
	private float xMax = 9f; 
	private float xMin = -9f;
	private Vector2 fireSpot;

	public GameObject meteor;
	public Text gameWonText;

	void Update () {
		FireMeteor();
	}

	void FireMeteor()
	{
		Quaternion q = Quaternion.identity;
		//q.z = 90;
		countdown -= Time.deltaTime;
		if (countdown <= 0)
		{
			ChangeFireSpot ();
			Instantiate (meteor, fireSpot, q);
			countdown = 2f;
		}
	}

	void ChangeFireSpot()
	{
		fireSpot = new Vector2(Random.Range(xMin, xMax), 5);
	}

	public void gameOver(int winner)
	{
		Time.timeScale = 0;
		gameWonText.text = "Player " + winner + " wins!";
	}
}