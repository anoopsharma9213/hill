using UnityEngine;
using System.Collections;

public class TerrainSpawner : MonoBehaviour {

	public GameObject fall, hill, swim, finish;
	int count;
	Vector3 spawnpos;

	// Use this for initialization
	void Start () {
		Random.seed = 20;
		spawnpos = new Vector3 (0, 0, 0);
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (count < 4) {
						spawnTerrain (Random.Range (1, 10));
						spawnpos = new Vector3 (spawnpos.x + 21, 0, 0);
						count++;
				} else if(Camera.main.transform.position.x > spawnpos.x-21) {
			//Debug.Break();
			Debug.Log(Camera.main.transform.position.x.ToString());
			count = 0;
				}
	}

	void spawnTerrain(int num)
	{
		if (num >= 1 && num < 4) {
			Instantiate(fall,spawnpos,Quaternion.Euler(0,0,0));
				} else if (num >= 4 && num < 7) {
			Instantiate(hill,spawnpos,Quaternion.Euler(0,0,0));
				} else if (num >= 7) {
			Instantiate(swim,spawnpos,Quaternion.Euler(0,0,0));
				}
	}
}
