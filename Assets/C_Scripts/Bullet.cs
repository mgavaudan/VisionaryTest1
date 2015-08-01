using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public int bulletSpeed;

	void Awake () {
		// Null checks
		if (!explosion) {
			explosion = GameObject.Find("Explosion");
		}
		GetComponent<Rigidbody>().velocity = GetComponent<Transform>().right * bulletSpeed;
	}
	
    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy" || collider.tag == "Boundary")
        {
			// destroy bullet on impact
            Destroy(gameObject);
        }

    }
}
