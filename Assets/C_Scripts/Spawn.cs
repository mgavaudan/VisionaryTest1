using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
	public GameObject cam;
	
	void Awake(){
		
		// Null checks
		if (!cam) {
			cam = GameObject.Find("Main cam");
		}
		if (!enemy) {
			enemy = GameObject.Find("Enemy");
		}
	}

	void Start(){
		// creating the enemy missiles
		StartCoroutine(SpawnEnemies ());
	}
	
	void Update () {
		// making the enemy ship move up and down
		GetComponent<Rigidbody>().position += Mathf.Sin(Time.time) * Vector3.down * Time.deltaTime*15;
	}

	IEnumerator SpawnEnemies(){

		while(true){
			// spawn between 4 and 30 enemies every second
			int numEnemies = Random.Range (4, 10);
			for (int i = 0; i < numEnemies; ++i) {
				Instantiate(enemy, GetComponent<Rigidbody>().position + Vector3.down * Random.Range (-5, 15) + Vector3.left * Random.Range (-2, 2), Quaternion.identity );
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
		
		

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Bullet")
        {
			// if a bullet hits we display the win gui and destroy this ship
			cam.GetComponent<EffectsMaster>().Flag = 1;
        }

    }	
	
}
