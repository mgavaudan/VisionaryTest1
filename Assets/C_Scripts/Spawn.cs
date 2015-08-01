using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;
	public GameObject cam;
	
	private Rigidbody rigid;

	// how far is the ship going?
	public float moveLen;

	// max and min number of spawns per half second
	public int numSpawnMax;
	public int numSpawnMin;

	// range of spawn area around craft
	public int spawnArea;

	public static bool playing = true;

	[Range(0.0f, 1.0f)]
	public float spawnRate;

	void Awake(){

		rigid = GetComponent<Rigidbody> ();

		if (!cam) {
			cam = GameObject.Find("Main Camera");
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

		Vector3 velocity = new Vector3 ( 0.0f, Shooter.Pos.y, 0).normalized * 10;
		rigid.MovePosition (rigid.position + velocity * Time.fixedDeltaTime);

	}
	
	IEnumerator SpawnEnemies(){
		
		while(playing){
			int numEnemies = Random.Range (numSpawnMin, numSpawnMax);
			for (int i = 0; i < numEnemies; ++i) {
				Instantiate(enemy, rigid.position + Vector3.down * Random.Range (-spawnArea, spawnArea) + Vector3.left * Random.Range (-2, 2), Quaternion.identity );
			}
			yield return new WaitForSeconds(spawnRate);
		}
	}
		
		

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Bullet") {
			// if a bullet hits we display the win gui and destroy this ship
			GetComponent<AudioSource>().Play();
			GameController.Flag = 1;
		} 
    }	
	
}
