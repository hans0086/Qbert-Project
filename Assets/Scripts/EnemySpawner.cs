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
	public float spawnTime = 7.0f;
	// Use this for initialization
	void Start () {
		//set spawn positions to the 2 cubes in the second row
		spawnPosition1 = spawnCube1.transform;
		spawnPosition2 = spawnCube2.transform;
		//spawnPosition1.position.y = spawnPosition1.position.y + 1;
		//spawnPosition2.position.y = spawnPosition2.position.y + 1;
	}
	
	// Update is called once per frame
	void Update () {
		//keep increasing the timer until it is time for a spider to spawn
		if (_elapsedTime < spawnTime) {
			_elapsedTime += Time.deltaTime;
		}
		//if it is time for a spider to spawn
		if (_elapsedTime > spawnTime) {
			//will randomly determine where the spider will spawn
			//if it is the left spawn point, play the spawn sound and make a spider prefab at that location. Then randomly set the spawnPosition for the next spawn time
			if (spawnPositionFlag == 0) {
				spawnSound.Play ();
				Instantiate (enemyPrefab, new Vector3 (spawnPosition1.position.x, spawnPosition1.position.y + 1, spawnPosition1.position.z), Quaternion.identity);
				spawnPositionFlag = Random.Range (0, 2);
			}
			//if it is the right spawn point, play the spawn sound and make a spider prefab at that location. Then randomly set the spawnPosition for the next spawn time
			else{
				spawnSound.Play ();
				Instantiate (enemyPrefab, new Vector3 (spawnPosition2.position.x, spawnPosition2.position.y + 1, spawnPosition2.position.z), Quaternion.identity);
				spawnPositionFlag = Random.Range (0, 2);
			}
			//reset the timer for the next spawn
			_elapsedTime = 0.0f;
		}
	}
}
