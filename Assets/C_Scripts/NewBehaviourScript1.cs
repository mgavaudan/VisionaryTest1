using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        randomOffset = Random.Range(0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Transform>().position -= GetComponent<Transform>().right * 3 * Time.deltaTime;
        GetComponent<Transform>().position += Mathf.Sign(Time.time + randomOffset) * Vector3.down * Time.deltaTime;

	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet!")
        {
            Destroy(gameObject);
        }
    }
}
