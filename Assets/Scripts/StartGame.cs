using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour {



    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
       
		
	}
    public void NewGame()
    {
        SceneManager.LoadScene(1);

    }
}
