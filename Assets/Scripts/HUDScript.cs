using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
    //timer stuff
    public Text timerText;
    public float timer = 0;

    //points stuff
    public Text pointsText;
    public int points = 0;

    //fuel stuff
	public Text fuelText;
	private landerMove landerMover;

    //velocity stuff
    public int hSpeed = 0; 
	public Text hSpeedText;
    public int vSpeed = 0;
    public Text vSpeedText;

    //altitude stuff
    public float altitude = 0;
    public Text altText;

	//Test obj
	public GameObject shuttle;
    private Rigidbody rb;
	private Transform tran;

    // Use this for initialization
	void Start () {

		rb = shuttle.GetComponent(typeof(Rigidbody)) as Rigidbody;
		tran = shuttle.GetComponent(typeof(Transform)) as Transform;
		landerMover = shuttle.GetComponent (typeof(landerMove)) as landerMove;
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
	    int minutes = Mathf.FloorToInt(timer / 60f);
		int seconds = Mathf.FloorToInt(timer - (minutes * 60f));
        timerText.text = string.Format("Time:    {0:00}:{1:00}", minutes, seconds);

        // timerText.text = (timer / 60).ToString("00") + ":" + (timer % 60).ToString("00");

        //if shuttle crashes, lose fuel

		fuelText.text = string.Format("Fuel:     {0000}", landerMover.fuel);

        //get horizontal velocity of shuttle
        hSpeed = Mathf.FloorToInt(rb.velocity.x);
        hSpeedText.text = string.Format("Horizontal Speed:     {000}", hSpeed);

        vSpeed = Mathf.FloorToInt(rb.velocity.y);
        vSpeedText.text = string.Format("Vertical Speed:           {00}", -vSpeed);

        //altitude = renderer.bounds.min.y - shuttle.position.y;
        altText.text = string.Format("Altitude:                  {00}", altitude);
    }
}
