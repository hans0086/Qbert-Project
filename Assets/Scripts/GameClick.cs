using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameClick : MonoBehaviour {
	private AudioSource _selectSound;
	private float _elapsedTime = 0.0f;
	private float loadTime = 1.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//if the Start Game button is clicked, go the the Game Scene and play a sound
	public void ClickGame(){
		//get the select sound from this game object and play it
		_selectSound = this.gameObject.GetComponent<AudioSource> ();
		_selectSound.Play ();
		//wait half a second for the sound to play before going to the game scene
		StartCoroutine (WaitUntilLoad ());

	}
	IEnumerator WaitUntilLoad(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (1);
	}
}
