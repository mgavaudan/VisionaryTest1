using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float randomOffset;

	// Use this for initialization
	void Start () {
        randomOffset = Random.Range(0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Transform>().position -= GetComponent<Transform>().right * 3 * Time.deltaTime;
        GetComponent<Transform>().position += Mathf.Sin(Time.time + randomOffset) * Vector3.down * Time.deltaTime;

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
