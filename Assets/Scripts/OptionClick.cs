using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class OptionClick : MonoBehaviour {
	private AudioSource _selectSound;
	private float _elapsedTime = 0.0f;
	private float loadTime = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	//if the options button is pressed, play the select sound and go to the options menu
	public void ClickOptions(){
		//find and play the select sound
		_selectSound = this.gameObject.GetComponent<AudioSource> ();
		_selectSound.Play ();
		//wait half a second for the sound to play before going to the options menu
		StartCoroutine (WaitUntilLoad ());

	}
	IEnumerator WaitUntilLoad(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (3);
	}
}
