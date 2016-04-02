using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GetScore : MonoBehaviour {
	public Text scoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//get the current score from the scoreTracker script
		scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
		//set the score textfield to the current score
		scoreText.text = score.score.ToString ();
	}
}
