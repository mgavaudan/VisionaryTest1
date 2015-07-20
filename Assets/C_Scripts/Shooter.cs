using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject prefa;
	public GameObject camera;
    private float timer;
	private int energy;
	private int speed;
	private float fireRate;

	void Awake(){

		timer = 0;
		energy = 3;
		speed = 2;
		fireRate = 0.3f;
	
		// Null checks
		if (!camera) {
			GameObject.Find("Main Camera");
		}
		if (!prefa) {
			GameObject.Find("Capsule");
		}

	}

	void Update ()
	{
		// checking if the player is shooting
		Shoot ();
		// checking if player is moving
		GetMove ();
		// checking if player activated ability
		Ability ();

	}

	void Shoot(){

		if (timer > fireRate) { 
			if (Input.GetButton("fire"))
			{
				GameObject.Instantiate(prefa, GetComponent<Transform>().position, Quaternion.AngleAxis(180, Vector3.left) );
			}
			timer = 0;
		}
		
		timer += Time.fixedDeltaTime;
	}

	void GetMove(){

		if (Input.GetButton ("Up")) {
			GetComponent<Transform> ().position += new Vector3 (0, speed * Time.deltaTime, 0);
		}
		
		if (Input.GetButton ("Down")) {
			GetComponent<Transform> ().position += new Vector3 (0, -speed * Time.deltaTime, 0);
		} 
		
		if (Input.GetButton ("Right")) {
			GetComponent<Transform> ().position += new Vector3 (speed * Time.deltaTime, 0, 0);
		} 
		
		if (Input.GetButton ("Left")) {
			GetComponent<Transform> ().position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		} 

	}

	void Ability(){

		if (Input.GetKeyUp ("1")&& energy>0) {
			StartCoroutine( ShootBurst() );
		}
		
		if (Input.GetKeyUp ("2") && energy>0) {
			// quadruple speed for 5 seconds
			StartCoroutine( SpeedBurst() );
			
		}
		if (Input.GetKeyUp ("3") && energy > 2) {
			// ultimate ability
			GameObject[] army = GameObject.FindGameObjectsWithTag ("Enemy");
			
			for(var i = 0 ; i < army.Length ; i ++)
			{
				Destroy(army[i]);
			}
		}
		if (Input.GetKeyUp ("r")) {  
			Application.LoadLevel (0);  
		} 

	}


	IEnumerator SpeedBurst () {
		speed=8;
		energy-=1;
		yield return new WaitForSeconds(5);
		speed =2;
	}

	IEnumerator ShootBurst () {
		fireRate = 0.08f;
		energy-=1;
		yield return new WaitForSeconds(5);
		fireRate = 0.3f;
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy")
        {
			camera.GetComponent<EffectsMaster>().flag = 2;
        }
    }

	void OnGUI(){

		GUI.Label( new Rect(5, Screen.height-25, Screen.width, Screen.height), "Energy Left:" + energy);
		GUI.Label( new Rect(205, Screen.height-25, Screen.width, Screen.height),  "Press: 1 for faster fireRate, 2 for speed burst and 3 to nuke");

	}

}








