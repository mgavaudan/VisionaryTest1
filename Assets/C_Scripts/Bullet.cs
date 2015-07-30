using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody>().velocity = GetComponent<Transform>().right * 50;
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
