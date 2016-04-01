using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeColour : MonoBehaviour {
	private Material cubeMaterial;
	private Color defaultColor;

	// Use this for initialization
	void Start () {
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		if (renderer != null) {
			cubeMaterial = renderer.material;
			defaultColor = cubeMaterial.color;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name.Contains ("Character")) {
			if (cubeMaterial.color.Equals (defaultColor)) {
				cubeMaterial.color = Color.blue;
				scoreTracker score = GameObject.Find ("ScoreKeeper").GetComponent<scoreTracker> ();
				score.score += 1;
				CountBlocks blockCounter = GameObject.Find ("BlockCounter").GetComponent<CountBlocks> ();
				blockCounter.blocksTouched += 1;
			}

		}
	}
}
