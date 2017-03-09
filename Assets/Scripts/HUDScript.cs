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
    public int fuel = 1000;
    public Text fuelText;

    //velocity stuff
    public int hSpeed = 0; 
	public Text hSpeedText;
    public int vSpeed = 0;
    public Text vSpeedText;

    //altitude stuff
    public float altitude = 0;
    public Text altText;

    //Test obj
    private Rigidbody rb;
    public Transform shuttle;

    // Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        timer ++;
         int hours = 0;
          int minutes = Mathf.FloorToInt(timer / 60f);
          int seconds = Mathf.FloorToInt(timer - minutes * 60f);
         timerText.text = string.Format("Time:    {0}:{0:00}:{1:00}", hours, minutes, seconds);

        // timerText.text = (timer / 60).ToString("00") + ":" + (timer % 60).ToString("00");

        //if shuttle crashes, lose fuel

        fuelText.text = string.Format("Fuel:     {0000}", fuel);

        //get horizontal velocity of shuttle
        hSpeed = Mathf.FloorToInt(rb.velocity.x);
        hSpeedText.text = string.Format("Horizontal Speed:     {000}", hSpeed);

        vSpeed = Mathf.FloorToInt(rb.velocity.y);
        vSpeedText.text = string.Format("Vertical Speed:           {00}", -vSpeed);

        //altitude = renderer.bounds.min.y - shuttle.position.y;
        altText.text = string.Format("Altitude:                  {0000}", altitude);
    }
}
