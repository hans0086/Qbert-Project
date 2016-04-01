using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject spawnCube1;
	public GameObject spawnCube2;
	public GameObject enemyPrefab;
	public AudioSource spawnSound;
	private Transform spawnPosition1;
	private Transform spawnPosition2;
	private int spawnPositionFlag = 0;
	private float _elapsedTime = 0.0f;
	private float spawnTime = 5.0f;
	// Use this for initialization
	void Start () {
		spawnPosition1 = spawnCube1.transform;
		spawnPosition2 = spawnCube2.transform;
		//spawnPosition1.position.y = spawnPosition1.position.y + 1;
		//spawnPosition2.position.y = spawnPosition2.position.y + 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (_elapsedTime < spawnTime) {
			_elapsedTime += Time.deltaTime;
		}
		if (_elapsedTime > spawnTime) {
			if (spawnPositionFlag == 0) {
				spawnSound.Play ();
				Instantiate (enemyPrefab, new Vector3 (spawnPosition1.position.x, spawnPosition1.position.y + 1, spawnPosition1.position.z), Quaternion.identity);
				spawnPositionFlag = 1;
			}
			else{
				spawnSound.Play ();
				Instantiate (enemyPrefab, new Vector3 (spawnPosition2.position.x, spawnPosition2.position.y + 1, spawnPosition2.position.z), Quaternion.identity);
				spawnPositionFlag = 0;
			}
			_elapsedTime = 0.0f;
		}
	}
}
