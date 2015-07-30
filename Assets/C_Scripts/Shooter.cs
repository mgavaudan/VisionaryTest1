using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
	public GameObject cam;

    private float timer;
	private int energy;
	private int speed;
	private Vector3 velocity;
	private float fireRate;
	private Rigidbody rigid;

	void Awake(){

		rigid = GetComponent<Rigidbody> ();

		timer = 0;
		speed = 10;
		energy = 3;
		fireRate = 0.3f;

	}

	void Start(){
	
		// Null checks
		if (!cam) {
			cam = GameObject.Find("Main cam");
		}
		if (!bullet) {
			bullet = GameObject.Find("Bullet");
		}
	
	
	}

	void Update ()
	{
		// checking if the player is shooting
		Shoot ();
		// checking if player activated ability
		Ability ();

	}

	void FixedUpdate() {
		// player movement
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0).normalized * speed;
		rigid.MovePosition (rigid.position + velocity * Time.fixedDeltaTime);
	}



	void Shoot(){

		if (timer > fireRate && Input.GetButton("Fire1")) { 
			Instantiate(bullet, GetComponent<Transform>().position, Quaternion.AngleAxis(180, Vector3.left) );
			timer = 0;
		}
		
		timer += Time.fixedDeltaTime;
	}


	void Ability(){

		if (Input.GetKeyUp ("1")&& energy>0) {
			StartCoroutine( ShootBurst() );
		}
		else if (Input.GetKeyUp ("2") && energy>0) {
			// quadruple speed for 5 seconds
			StartCoroutine( SpeedBurst() );
			
		}
		else if (Input.GetKeyUp ("3") && energy > 2) {
			// ultimate ability
			GameObject[] army = GameObject.FindGameObjectsWithTag ("Enemy");
			
			for(var i = 0 ; i < army.Length ; i ++)
			{
				Destroy(army[i]);
			}
		}

		// restart the level
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
			cam.GetComponent<EffectsMaster>().Flag = 2;
        }
    }

	void OnGUI(){

		GUI.Label( new Rect(5, Screen.height-25, Screen.width, Screen.height), "Energy Left:" + energy);
		GUI.Label( new Rect(205, Screen.height-25, Screen.width, Screen.height),  "Press: 1 for faster fireRate, 2 for speed burst and 3 to nuke");

	}

}








