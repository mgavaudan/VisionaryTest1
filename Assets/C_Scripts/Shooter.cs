using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject prefa;
    private float timer = 0;
void Update ()
{
if (timer > 0.08f) { 
if (Input.GetButton("fire"))
{
GameObject.Instantiate(prefa).GetComponent<Transform>().position = GetComponent<Transform>().position + GetComponent<Transform>().right * 1.05;
}
timer = 0;
}
timer += Time.fixedDeltaTime;

if (Input.GetButton("Up"))
{
GetComponent<Transform>().position += new Vector3(0, 2 * Time.deltaTime, 0);
}
if (Input.GetButton("Down"))
{

}
}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
