﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astriods : MonoBehaviour {

	Transform myT;
	Vector3 randomeRotation;
	public float ScaleOffsetX =1.5f;
	public float ScaleOffsetY =1.5f;
	public float ScaleOffsetZ =1.5f;
    public float RotationOffset =5f;
	public float movementSpeed= 50.0f;
	public float GameArea = 500000;


	void Awake()
	{
		myT = transform;
	}

	void Start () {
		//Vector3 scale = Vector3.one;

		ScaleOffsetX = Random.Range (-ScaleOffsetX,ScaleOffsetX);
		ScaleOffsetY = Random.Range (-ScaleOffsetY, ScaleOffsetY);
		ScaleOffsetZ = Random.Range (-ScaleOffsetZ, ScaleOffsetZ);
		myT.localScale = scale(ScaleOffsetX,ScaleOffsetY,ScaleOffsetZ);

		randomeRotation.x = Random.Range (-RotationOffset,  RotationOffset);
		randomeRotation.y = Random.Range (-RotationOffset,  RotationOffset);
		randomeRotation.z = Random.Range (-RotationOffset,  RotationOffset);
	}

	private Vector3 scale(float x, float y ,float z)
	{
		Vector3 scale = new Vector3 ( x,y,z);
		return scale;
	}

	void Update () {
		InGameRange ();
		myT.Rotate (randomeRotation.x * Time.deltaTime,randomeRotation.y * Time.deltaTime,randomeRotation.z * Time.deltaTime);
		myT.position += transform.forward * movementSpeed;

	}

	private void InGameRange()
	{
		if (myT.position.x >= GameArea) {
			myT.position = new Vector3 (-GameArea, myT.position.y, myT.position.z);
			//Debug.Log ("36");
		} else if (myT.position.x <= -GameArea) {
			myT.position = new Vector3 (GameArea, myT.position.y, myT.position.z);
			//Debug.Log ("37");
		} else if (transform.position.z >= GameArea) {
			myT.position = new Vector3 (myT.position.x, myT.position.y, -GameArea);
			//Debug.Log ("38");
		} else if (myT.position.z <= -GameArea) {
			myT.position = new Vector3 (myT.position.x, myT.position.y, GameArea);
			//Debug.Log ("39");
		}
		else if (transform.position.y >= GameArea) {
			myT.position = new Vector3 (myT.position.x, -GameArea, myT.position.z);
			//Debug.Log ("38");
		} else if (myT.position.y <= -GameArea) {
			myT.position = new Vector3 (myT.position.x, GameArea, myT.position.z);
			//Debug.Log ("39");
		}


		if (myT.position.y > GameArea) {
			myT.position = new Vector3 (myT.position.x, GameArea, myT.position.z);
			//Debug.Log ("40");
		}
	}
}
