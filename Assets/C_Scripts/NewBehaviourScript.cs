using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Transform>().eulerAngles = new Vector3(GetComponent<Transform>().eulerAngles.z, GetComponent<Transform>().eulerAngles.y, Random.Range(-45, 45));
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Transform>().position -= GetComponent<Transform>().right * 10 * Time.fixedDeltaTime; // here
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
