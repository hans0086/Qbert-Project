using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 1.0f;
	private bool hasTouchedBlock = true;


	public AudioSource deadSound;
	public AudioSource jumpSound;
	private Vector3 startingPosition;
	private bool _isFalling = false;
	private float _startingYPos;
	private int _lives = 3;

	void Start() {
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		startingPosition = this.transform.position;
	}

	void Update() {
		if (hasTouchedBlock) {
			
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				hasTouchedBlock = false;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				this.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				hasTouchedBlock = false;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				this.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				hasTouchedBlock = false;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				this.transform.rotation = Quaternion.Euler (0.0f, 270.0f, 0.0f);
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				hasTouchedBlock = false;
			}
		}
		if (this.transform.position.y < -2) {
			deadSound.Play ();
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name.Contains ("Cube"))
			hasTouchedBlock = true;
		if (collision.gameObject.name.Contains ("spider")) {
			lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
			lives.lives -= 1;
			if (lives.lives == 0) {
				Application.LoadLevel (2);
			}
			Destroy (collision.gameObject);
			deadSound.Play ();
			
		}
		if (collision.gameObject.name.Contains ("Warp")) {
			this.transform.position = startingPosition;
			Destroy (collision.gameObject);
		}
	}
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name.Contains ("Bottom")) {
			this.transform.position = startingPosition;
			lifeTracker lives = GameObject.Find ("LivesKeeper").GetComponent<lifeTracker> ();
			lives.lives -= 1;
			if (lives.lives == 0) {
				Application.LoadLevel (2);
			}
		}
	}
}
