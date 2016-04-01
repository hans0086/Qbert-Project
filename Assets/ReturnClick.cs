using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ReturnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ClickReturn(){
		Application.LoadLevel (0);
	}
}
