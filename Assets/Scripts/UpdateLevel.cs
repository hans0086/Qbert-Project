using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UpdateLevel : MonoBehaviour {
	public Text levelText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//get the current level from the LevelCounter script
		LevelCounter level = GameObject.Find("LevelMarker").GetComponent<LevelCounter> ();
		//set the textfield value to the current level number
		levelText.text = level.level.ToString ();
	}
}
