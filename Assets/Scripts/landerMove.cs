using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class landerMove : MonoBehaviour {

    // This changes the force applied to the rocket on thrusting
    [SerializeField]private float forceMult;
    // This is the fuel modifier. Higher values = lower fuel usage.
    [SerializeField]private float fuelMod;

    public float fuel;

    // The lander's RigidBody
	private Rigidbody landMove;
    private float upforce;
    
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
            fuel -= upforce / fuelMod;
        }
        // transform.up is the up vector of the object. We multiply it by force and the multiplier
        landMove.AddForce (transform.up*upforce*forceMult);
        transform.Rotate (new Vector3 (0f, 0f, Input.GetAxis("Horizontal")));
	}
}
