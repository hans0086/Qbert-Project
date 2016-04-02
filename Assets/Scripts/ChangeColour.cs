using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeColour : MonoBehaviour {
	private Material cubeMaterial;
	private Color defaultColor;

	// Use this for initialization
	void Start () {
		//get this object's MeshRenderer
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		if (renderer != null) {
			// get this objects material
			cubeMaterial = renderer.material;
			//get this objects initial colour and set it to the default color, to test against later
			defaultColor = cubeMaterial.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		//get the curret level and round from the LevelCounter script
		LevelCounter level = GameObject.Find ("LevelMarker").GetComponent<LevelCounter> ();
		//if the player collides touches a block
		if (collision.gameObject.name.Contains ("Character")) {
			//if this is the first level
			if (level.level == 1) {
				//if the block hasn't been touched by the player yet
				if (cubeMaterial.color.Equals (defaultColor)) {
					//set the block's colour to blue
					cubeMaterial.color = Color.blue;
					//get the current score from the scoreTracker Script
					scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
					//increase it by 1
					score.score += 1;
					//get the number of blocks touched from the CountBlocks Script
					CountBlocks blockCounter = GameObject.Find ("BlockCounter").GetComponent<CountBlocks> ();
					//increase the number of blocks touched by 1
					blockCounter.blocksTouched += 1;
				}
			//if this is the 2nd level
			} else {
				//if the block has been touched once
				if (cubeMaterial.color.Equals (Color.blue)) {
					//set the block's colour to cyan
					cubeMaterial.color = Color.cyan;
					//get the current score from the scoreTracker Script
					scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
					//increase the score by 1
					score.score += 1;
					//get the number of blocks touched from the CountBlocks script
					CountBlocks blockCounter = GameObject.Find ("BlockCounter").GetComponent<CountBlocks> ();
					//increase the number of blocks touched by 1
					blockCounter.blocksTouched += 1;
				}
				//if the block hasn't been touched yet, set it to blue
				if (cubeMaterial.color.Equals (defaultColor)) {
					//set the block colour to blue
					cubeMaterial.color = Color.blue;
					//get the current score from the scoreTracker script
					scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
					//increase the score by 1
					score.score += 1;
					//get the number of blocks touched from the CountBlocks script
					CountBlocks blockCounter = GameObject.Find ("BlockCounter").GetComponent<CountBlocks> ();
					//increase the number of touched blocks by 1
					blockCounter.blocksTouched += 1;
				}

			}

		}
	}
}
