using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float randomOffset;
	
	void Start () {
        randomOffset = Random.Range(0f, 1f);
	}

	void Update () {
		// move the enemy missiles
        GetComponent<Transform>().position -= GetComponent<Transform>().right * 3 * Time.deltaTime;
        GetComponent<Transform>().position += Mathf.Sin(Time.time + randomOffset) * Vector3.down * Time.deltaTime;

		// destroy the missiles if they exit the screen
		if (GetComponent<Transform> ().position.x < -15) {
			Destroy (gameObject);
		}
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
