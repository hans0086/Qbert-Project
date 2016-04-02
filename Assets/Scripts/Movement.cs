using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 1.0f;
	private bool hasTouchedBlock = true;
	public AudioSource deadSound;
	public AudioSource jumpSound;
	public AudioSource warpSound;
	public Vector3 startingPosition;

	void Start() {
		//don't allow the player to tip over or fall from physics related movement
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		//get the starting position
		startingPosition = this.transform.position;
	}

	void Update() {
		//if the player has touched a block after "jumping", allow another jump
		if (hasTouchedBlock) {
			//if the down arrow is pressed, move the player south east
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				//turn the player south east
				this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
				//move the player south east
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				//play the jump sound
				jumpSound.Play ();
				//player has not touched a block, so set hasTouchedBlock to false
				hasTouchedBlock = false;
			}
			//if the up arrow is pressed, move the player to the north west
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				//turn the player toward the north west
				this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				//move the player south west
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				//play the jump sound
				jumpSound.Play ();
				//player has not touched a block so set hasTouchedBlock to false
				hasTouchedBlock = false;
			}
			//if the right arrow is pressed, move the player to the north east
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				//turn the player north east
				this.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				//move the player north east
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				//play the jump sound
				jumpSound.Play ();
				//player hasn't touched a block so set hasTouchedBlock to false
				hasTouchedBlock = false;
			}
			//if the left arrow is pressed, move the player south west
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				//turn the player south west
				this.transform.rotation = Quaternion.Euler (0.0f, 270.0f, 0.0f);
				//move the player south west
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				//play the jump sound
				jumpSound.Play ();
				//player hasn't touched a block so set hasTouchedBlock to false
				hasTouchedBlock = false;
			}
		}
		//if player falls below the blocks, play the dead sound
		if (this.transform.position.y < -2) {
			deadSound.Play ();
		}
	}
	void OnCollisionEnter(Collision collision) {
		//if the player touches a cube, they are able to jump again
		if (collision.gameObject.name.Contains ("Cube"))
			//player can now jump again
			hasTouchedBlock = true;
		//if the player touches a spider, they will lose a life and the spider will dissappear
		if (collision.gameObject.name.Contains ("spider")) {/*
			//get the current number of lives from the lifeTracker script
			lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
			//remove a life
			lives.lives -= 1;
			//end the game if the number of lives hit zero
			if (lives.lives == 0) {
				Application.LoadLevel (2);
			}
			//destroy the spider object
			Destroy (collision.gameObject);
			//play the sound for death
			deadSound.Play ();*/
			
		}
		//if the player touches a warp pad, play the warp sound and bring the player back to the starting position
		if (collision.gameObject.name.Contains ("Warp")) {
			warpSound.Play ();//warp sound
			//send player to starting position
			this.transform.position = startingPosition;

		}
	}
	//if the player falls off the map and hits the bottom floor, lose a life or end game if out of lives
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name.Contains ("Bottom")) {
			//send player to starting position
			this.transform.position = startingPosition;
			//get the number of lives from the lifeTracker script
			lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
			//remove a life
			lives.lives -= 1;
			//if no more lives, go to Game Over screen
			if (lives.lives == 0) {
				Application.LoadLevel (2);
			}
		}
	}
}
