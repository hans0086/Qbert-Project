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
		scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
		scoreText.text = score.score.ToString ();
	}
}
