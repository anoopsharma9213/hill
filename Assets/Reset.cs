using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Camera.main.transform.position.x, 0, 0);
	}

	void OnMouseUpAsButton ()
	{
		Debug.Log("Refresh");
		Application.LoadLevel ("Level_1");
	}
}
