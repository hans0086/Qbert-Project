using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class resetGame : MonoBehaviour {
	private AudioSource _selectSound;
	private float _elapsedTime = 0.0f;
	private float loadTime = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//if the Reset button is pressed, play the select sound and go back to the main menu
	public void GameReset(){
		//find and play the select sound
		_selectSound = this.gameObject.GetComponent<AudioSource> ();
		_selectSound.Play ();
		//wait half a second for the sound to play and go back to the main menu
		StartCoroutine (WaitUntilLoad ());
	}
	IEnumerator WaitUntilLoad(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (0);
	}
}

