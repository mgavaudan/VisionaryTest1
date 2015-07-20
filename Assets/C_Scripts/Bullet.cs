using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	void Start () {
		// making our ship's bullets go in random angles
        GetComponent<Transform>().eulerAngles = new Vector3(GetComponent<Transform>().eulerAngles.z, GetComponent<Transform>().eulerAngles.y, Random.Range(-45, 45));
	}
	

	void Update () {

        GetComponent<Transform>().position -= GetComponent<Transform>().right * 10 * Time.fixedDeltaTime;
		// cleaning up the bullets once they leave the main area
		if (GetComponent<Transform> ().position.x > 15) {
			Destroy (gameObject);
		}

	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy")
        {
			// destroy bullet on impact
            Destroy(gameObject);
        }

    }
}
