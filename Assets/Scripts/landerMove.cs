using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody))]
public class landerMove : MonoBehaviour {

    // This changes the force applied to the rocket on thrusting
    [SerializeField]private float forceMult;
    // This is the fuel modifier. Higher values = lower fuel usage.
    [SerializeField]private float fuelMod;
	// This is the afterburner effect
	[SerializeField]private GameObject afterBurner;
	// The end game button
	[SerializeField]private GameObject endGame;
	// The sounds for our lander
	[SerializeField]private AudioSource explosion;
	[SerializeField]private AudioSource thruster;


    public float fuel;

    // The lander's RigidBody
	private Rigidbody landMove;
    private float upforce;
	private bool dead = false;
    
	void Start () {
        landMove = GetComponent(typeof(Rigidbody)) as Rigidbody;
        landMove.AddForce(Vector3.left*20000.0f);
        fuel = 1000;
	}
	
    // We're using fixedupdate because we're using physics.
	void FixedUpdate () {
        if (fuel > 0.0f)
        {
            upforce = Input.GetAxis("Vertical");
            upforce = Mathf.Max(0.0f, upforce);
			if (upforce > 0.1f && !afterBurner.activeSelf) {
				afterBurner.SetActive (true);
				thruster.Play ();
			} else if (upforce <= 0.1f && afterBurner.activeSelf) {
				thruster.Stop ();
				afterBurner.SetActive (false);
			}
            fuel -= upforce / fuelMod;
        }
        // transform.up is the up vector of the object. We multiply it by force and the multiplier
        landMove.AddForce (transform.up*upforce*forceMult);
        transform.Rotate (new Vector3 (0f, 0f, Input.GetAxis("Horizontal")));
	}

	void OnCollisionEnter(Collision coll) {
		if (dead)
			return;
		dead = true;
		explosion.Play ();
		endGame.SetActive (true);
	}
}
