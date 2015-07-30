using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float randomOffset;
	
	void Start () {
		GetComponent<Rigidbody>().velocity = GetComponent<Transform>().right * -15;
        randomOffset = Random.Range(0f, 1f);
	}

	void Update () {
		// move the enemy missiles
        GetComponent<Rigidbody>().position += Mathf.Sin(Time.time + randomOffset) * Vector3.down * Time.deltaTime;
	}

    void OnTriggerEnter(Collider collider)
    {
		if (collider.tag == "Bullet" || collider.tag== "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
