using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
	public GameObject camera;
	private float timer;


	void Awake(){
		
		// Null checks
		if (!camera) {
			GameObject.Find("Main Camera");
		}
		if (!enemy) {
			GameObject.Find("Capsule (1)");
		}
		
	}
	
	void Update () {

		// making the enemy ship move up and down
		GetComponent<Transform>().position += Mathf.Sin(Time.time) * Vector3.down * Time.deltaTime;
		// creating the little creatures
		SpawnEnemies ();
	}

	void SpawnEnemies(){

		if (timer > 1) {
			timer = 0;
			// spawn between 4 and 30 enemies every second
			int numEnemies = Random.Range (4, 30);
			for (int i = 0; i < numEnemies; ++i) {
				GameObject spawned = GameObject.Instantiate (enemy);
				spawned.GetComponent<Transform> ().position = GetComponent<Transform> ().position + Vector3.down * Random.Range (-5, 15) + Vector3.left * Random.Range (-2, 2);
			}
		}
		timer += Time.fixedDeltaTime;
	}
		
		

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Bullet")
        {
			// if a bullet hits we display the win gui and destroy this ship
			camera.GetComponent<EffectsMaster>().flag = 1;
        }

    }	
	
}
