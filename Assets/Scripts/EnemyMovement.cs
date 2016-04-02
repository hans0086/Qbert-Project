using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private int moveDirection = 1;
	private float _elapsedTime=0.0f;
	public float moveTime = 2.0f;
	public float turnTimer = 1.0f;
	private float _elapedTurn = 0.0f;
	public AudioSource jumpSound;
	public AudioSource fallingSound;
	private LevelCounter level;
	private int levelNum;
	private int roundNum;
	// Use this for initialization
	void Start () {
		//get the jump sound attached to the camera
		jumpSound = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		//get the falling sound attached to this object
		fallingSound = this.gameObject.GetComponent<AudioSource> ();
		//stop the enemy from tipping over from physics acting on the object
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		//make the enemy face south west
		this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
		//get the level number from LevelCounter script
		level = GameObject.Find ("LevelMarker").GetComponent<LevelCounter> ();
		//set the level and round number
		levelNum = level.level;
		roundNum = level.round;
	}
	
	// Update is called once per frame
	void Update () {
		//move the spider every 2 seconds
		if (_elapsedTime > moveTime) {
			//reset timer
			_elapsedTime = 0.0f;
			//will randomly move the spider south west or south east depending on what moveDirection is set to
			//move spider south west
			if (moveDirection == 1) {
				//turn the spider in the direction it is moving
				this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
				//while (_elapedTurn < turnTimer) {
				//	_elapedTurn += Time.deltaTime;
				//}
				//reset timer
				_elapedTurn = 0.0f;
				//move the spider south west
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				//randomly set moveDirection for next move action
				moveDirection = Random.Range (0, 2);
			//move spider south east
			} else {
				//turn the spider in the direction it is moving
				this.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				//while (_elapedTurn < turnTimer) {
				//	_elapedTurn += Time.deltaTime;
				//}
				//reset timer
				_elapedTurn = 0.0f;
				//move the spider south east
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				jumpSound.Play ();
				//randomly set moveDirect for next move action
				moveDirection = Random.Range (0, 2);
			}
			//increase time if spider hasn't moved yet
		} else {
			_elapsedTime += Time.deltaTime;
		}
		//if the level or round has changed, destroy the game object to reset the level
		if (level.level > levelNum || level.round > roundNum) {
			Destroy (this.gameObject);
			_elapsedTime = 0.0f;
		}


	}
	//if the spider hits the bottom of the level, destroy it
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name.Contains ("Bottom")) {
			fallingSound.Play ();
			Destroy (this.gameObject);
		}

	}
}
