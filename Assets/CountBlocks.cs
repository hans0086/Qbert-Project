using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CountBlocks : MonoBehaviour {
	public int blocksTouched = 0;
	public List<GameObject> blocks;
	private Material _renderer;
	private MeshRenderer _blockRenderer;
	private Color defaultColor;
	// Use this for initialization
	void Start () {
		_blockRenderer = GameObject.Find("Cube").GetComponent<MeshRenderer> ();
		_renderer = _blockRenderer.material;
		defaultColor = _renderer.color; 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (blocksTouched);
		if (blocksTouched == 21) {
			Debug.Log ("ALL HAVE BEEN MARKED");
			foreach (GameObject block in blocks) {
				_blockRenderer = block.GetComponent<MeshRenderer> ();
				_renderer = _blockRenderer.material;
				_renderer.color = defaultColor;
			}
			blocksTouched = 0;
			LevelCounter level = GameObject.Find ("LevelMarker").GetComponent<LevelCounter> ();
			level.round += 1;
			if (level.round == 4) {
				level.round = 1;
				level.level += 1;
			}
		}

	}
}
