using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
	public GameObject camera;
	private float timer;
	
	void Update () {

		GetComponent<Transform>().position += Mathf.Sin(Time.time) * Vector3.down * Time.deltaTime;
		SpawnEnemies ();
	}

	void SpawnEnemies(){

		if (timer > 1) {
			timer = 0;
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
			camera.GetComponent<Guimaster>().flag = 1;
			Destroy(gameObject);
        }

    }	
	
}
