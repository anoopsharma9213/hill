using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	float jump;
	bool isdead;
	public GameObject text;

	public Sprite[] sprite;
	public SpriteRenderer sr;
	public float fps;

	public Vector2 force, oppforce;

	// Use this for initialization
	void Start () {

		sr = GetComponent<Renderer>() as SpriteRenderer;

		speed = 0.2f;
		jump = -1;
		isdead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;
		if (Input.GetButton ("Fire1") && isdead == false) {
						Debug.Log (Camera.main.ScreenToWorldPoint (Input.mousePosition).x.ToString ());
						if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x <= Camera.main.transform.position.x - 5.7f) {
								GetComponent<Rigidbody2D>().AddForce(oppforce);//pos = new Vector3 (transform.position.x - speed, transform.position.y);
								int index = (int)(Time.timeSinceLevelLoad * fps);
								index = index % sprite.Length;
								sr.sprite = sprite [index];
						} else if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x <= Camera.main.transform.position.x) {
								GetComponent<Rigidbody2D>().AddForce(force);//pos = new Vector3 (transform.position.x + speed, transform.position.y);
								int index = (int)(Time.timeSinceLevelLoad * fps);
								index = index % sprite.Length;
								sr.sprite = sprite [index];
						} else if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > Camera.main.transform.position.x && jump == -1) {
								jump = 20;
								GetComponent<Rigidbody2D>().isKinematic = true;
						}
				} else {
						sr.sprite = sprite [1];
				}
		if (jump > 0) {
						pos = new Vector3 (transform.position.x, transform.position.y + speed);
						jump--;
				} else {
			GetComponent<Rigidbody2D>().isKinematic = false;
				}

		if (pos.x < -9.5f) {
			pos.x = -9.5f;
				}
		if (pos.y < -6.4f && isdead == false) {
						pos.y = -7.0f;
						pos.x = 0;
						GetComponent<Rigidbody2D>().isKinematic = false;
						isdead = true;
						Instantiate (text, new Vector3(Camera.main.transform.position.x,0,0), Quaternion.Euler (0, 0, 0));
				} else {
			transform.position = pos;
				}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		jump = -1;
	}
}
