using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CountBlocks : MonoBehaviour {
	public int blocksTouched = 0;
	public List<GameObject> blocks;
	private Material _renderer;
	private MeshRenderer _blockRenderer;
	private Color defaultColor;
	public GameObject character;
	private float _updateEnemySpawnTime = 6.0f;
	// Use this for initialization
	void Start () {
		//get the Cube's MeshRenderer
		_blockRenderer = GameObject.Find("Cube").GetComponent<MeshRenderer> ();
		//get the block's material
		_renderer = _blockRenderer.material;
		//set the default colour
		defaultColor = _renderer.color; 
	}
	
	// Update is called once per frame
	void Update () {
		//get the level and round number from the LevelCounter script
		LevelCounter level = GameObject.Find ("LevelMarker").GetComponent<LevelCounter> ();
		//if this is the first level
		if (level.level == 1) {
			//if all blocks on the level have been touched once
			if (blocksTouched == 21) {
				//set each block back to its default yellow colour
				foreach (GameObject block in blocks) {
					_blockRenderer = block.GetComponent<MeshRenderer> ();
					_renderer = _blockRenderer.material;
					_renderer.color = defaultColor;
				}
				//set the player back to its starting position to start the next round
				Movement charMovement = character.GetComponent<Movement> ();
				character.transform.position = charMovement.startingPosition;
				//reset the number of blocks touched
				blocksTouched = 0;
				//increase the round number
				level.round += 1;
				//shorten the enemy spawn time
				_updateEnemySpawnTime -= 1.0f;
				//if the round is higher than 4, go to the next level
				if (level.round > 4) {
					level.round = 1;
					level.level += 1;
					//set enemy spawn time back to its original value
					_updateEnemySpawnTime = 6.0f;
				}
				//access the EnemySpawner script to change it's spawn time
				EnemySpawner spawner = GameObject.Find ("Main Camera").GetComponent<EnemySpawner> ();
				spawner.spawnTime = _updateEnemySpawnTime;
			}
		//if this is the 2nd level
		} else {
			//if all blocks have been touched twice
			if (blocksTouched == 42) {
				//set all blocks back to their default colour
				foreach (GameObject block in blocks) {
					_blockRenderer = block.GetComponent<MeshRenderer> ();
					_renderer = _blockRenderer.material;
					_renderer.color = defaultColor;
				}
				//put the player back to their starting position
				Movement charMovement = character.GetComponent<Movement> ();
				character.transform.position = charMovement.startingPosition;
				//reset the number of blocks touched
				blocksTouched = 0;
				//increase the round number
				level.round += 1;
				//shorten the enemy spawn time
				_updateEnemySpawnTime -= 1.0f;
				//increase the level if round is higher than 4
				if (level.round > 4) {
					level.round = 1;
					level.level += 1;
					// go to game finish screen if level is complete
					if (level.level == 3) {
						Application.LoadLevel (4);
						_updateEnemySpawnTime = 6.0f;
					}
					//update the enemy spawn time
					EnemySpawner spawner = GameObject.Find ("Main Camera").GetComponent<EnemySpawner> ();
					spawner.spawnTime = _updateEnemySpawnTime;

				}
			}


		}
	}
}
