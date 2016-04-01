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
		lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
		livesText.text = lives.lives.ToString ();
	}
}
