using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UpdateRound : MonoBehaviour {
	public Text roundText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//get the round number from the LevelCounter script
		LevelCounter round = GameObject.Find("LevelMarker").GetComponent<LevelCounter> ();
		//set the textfield value to the current round number
		roundText.text = round.round.ToString ();
	}
}
