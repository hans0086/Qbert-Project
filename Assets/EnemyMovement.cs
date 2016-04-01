using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private int moveDirection = 1;
	private float _elapsedTime=0.0f;
	public float moveTime = 2.0f;
	public float turnTimer = 1.0f;
	private float _elapedTurn = 0.0f;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_elapsedTime > moveTime) {
			_elapsedTime = 0.0f;
			if (moveDirection == 1) {
				this.transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
				while (_elapedTurn < turnTimer) {
					_elapedTurn += Time.deltaTime;
				}
				_elapedTurn = 0.0f;
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				moveDirection = Random.Range (0, 2);
			} else {
				this.transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				while (_elapedTurn < turnTimer) {
					_elapedTurn += Time.deltaTime;
				}
				_elapedTurn = 0.0f;
				transform.Translate (new Vector3 (0.0f, 0.7f, 1.0f));
				moveDirection = Random.Range (0, 2);
			}
		} else {
			_elapsedTime += Time.deltaTime;
		}
	}
}
