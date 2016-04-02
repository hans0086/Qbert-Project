using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GetLives : MonoBehaviour {
	public Text livesText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//get the current number of lives from the lifeTracker script
		lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
		//set the text field equal to the current number of lives
		livesText.text = lives.lives.ToString ();
	}
}
