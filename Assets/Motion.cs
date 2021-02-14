using UnityEngine;
using System.Collections;

public class Motion : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
				}
		//transform.position = new Vector3 (transform.position.x + speed, 0, -10);
		Vector3 pos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		if (pos.y < 0) {
			pos.y = 0;
				}
		if (pos.x < 0) {
			pos.x = 0;
				}
		transform.position = new Vector3 (pos.x, pos.y, -10);


	}
}
