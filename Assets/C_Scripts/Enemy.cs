using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float randomOffset;
	private Rigidbody rigid;

	[Range(0.0f, 30.0f)]
	public float speed = 15f;
	
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		rigid.velocity = GetComponent<Transform>().right * -speed;
        randomOffset = Random.Range(0f, 1f);
	}

	void Update () {
		// move the enemy missiles
        rigid.position += Mathf.Sin(Time.time + randomOffset) * Vector3.down * Time.deltaTime;
	}

    void OnTriggerEnter(Collider collider)
    {
		if (collider.tag == "Bullet" || collider.tag== "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
