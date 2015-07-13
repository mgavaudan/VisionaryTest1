using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}

    float timer = 0;
	// Update is called once per frame
	void Update () {

        if (timer > 1)
        {
            timer = 0;
            var numEnemies = Random.Range(4, 30);
            for (var i = 0; i < numEnemies; ++i)
            {
                var spawned = GameObject.Instantiate(enemy);
                            spawned.GetComponent<Transform>().position = GetComponent<Transform>().position + Vector3.down * Random.Range(0, 10) + Vector3.left * Random.Range(-2, 2);
            }
        }

        timer += Time.fixedDeltaTime;
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
