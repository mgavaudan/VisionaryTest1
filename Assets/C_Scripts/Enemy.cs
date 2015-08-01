using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosion;
	public float maxRadiansDelta;

	[Range(0.0f, 30.0f)]
	public float speed;
	
	void Awake () {

		// Null checks
		if (!explosion) {
			explosion = GameObject.Find("Explosion");
		}
		StartCoroutine (Homing());
	}


	IEnumerator Homing()
	{
		while(true)
		{
			transform.position += transform.forward * speed * Time.deltaTime;

			if (transform.position.x>Shooter.Pos.x){
				transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (Shooter.Pos - transform.position).normalized, maxRadiansDelta, 1f));
			}


			yield return null;
		}
	}

    void OnTriggerEnter(Collider collider)
    {
		if (collider.tag == "Bullet") {
			Instantiate (explosion, collider.transform.position, collider.transform.rotation);
			Destroy (gameObject);
		} 

		else if (collider.tag == "Boundary") {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

		}
    }
}
