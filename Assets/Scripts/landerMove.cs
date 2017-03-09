using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landerMove : MonoBehaviour {

	GameObject lander;
	Rigidbody landMove;

	float gravity;
	float fuel;

	// Use this for initialization
	void Start () {
		lander = GameObject.Find ("Cube");
		landMove = GetComponent<Rigidbody> ();
		gravity = -1.622f;	//in m/s^2
		Physics.gravity = new Vector3(0f, gravity, 0f);
		fuel = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){
			if (fuel > 0) {
				landMove.AddForce (new Vector3 (0f, 1.5f, 0f));
				fuel -= .1f;
			}
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			lander.transform.Rotate (new Vector3 (0f, 0f, 1f));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			lander.transform.Rotate (new Vector3 (0f, 0f, -1f));
		}
	}
}
