using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class OptionClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ClickOptions(){

		Application.LoadLevel (3);
	}
}
