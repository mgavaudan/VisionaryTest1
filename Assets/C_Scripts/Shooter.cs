using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
	public GameObject cam;

	[Range(0, 30)]
	public int energy;

	[Range(0.0f, 30.0f)]
	public float speed;

	[Range(0.0f, 1.0f)]
	public float fireRate;

	private float timer;
	private Rigidbody rigid;
		
	private static Vector3 pos;
	
	public static Vector3 Pos {
		get{
			return pos;
		}
	}

	void Awake(){

		rigid = GetComponent<Rigidbody> ();
		timer = 0f;

	}

	void Start(){
	
		// Null checks
		if (!cam) {
			cam = GameObject.Find("Main Camera");
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

	#region Input Controller

	void FixedUpdate() {
		// player movement
		Vector3 velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0).normalized * speed;
		rigid.MovePosition (rigid.position + velocity * Time.fixedDeltaTime);
		pos = rigid.position;
	}



	void Shoot(){

		if (timer > fireRate && Input.GetButton("Fire1")) { 
			Instantiate(bullet, rigid.position, Quaternion.AngleAxis(180, Vector3.left) );
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
			// destroy all enemies
			StartCoroutine(Nuke());
		}

		// restart the level
		if (Input.GetKeyUp ("r")) {  
			Application.LoadLevel (0);  
		} 

	}

	#endregion

	#region Abilities

	IEnumerator Nuke(){
	
		// ultimate ability
		GameObject[] army = GameObject.FindGameObjectsWithTag ("Enemy");
		for(var i = 0 ; i < army.Length ; i ++)
		{
			Destroy(army[i]);
		}
		energy-=3;

		yield return new WaitForSeconds(1);
	}

	IEnumerator SpeedBurst () {

		speed*=2;
		energy-=1;
		yield return new WaitForSeconds(5);
		speed /=2;
	}

	IEnumerator ShootBurst () {
		fireRate /= 3;
		energy-=1;
		yield return new WaitForSeconds(5);
		fireRate *= 3;
	}

	#endregion

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Enemy")
        {
			Spawn.playing=false;
			energy+=3;
			StartCoroutine(Nuke());
			GetComponent<AudioSource>().Play();
			GameController.Flag = 2;
        }
    }
	

	void OnGUI(){
		
		GUI.Label( new Rect(5, Screen.height-25, Screen.width, Screen.height), "Energy Left:" + energy);
		GUI.Label( new Rect(205, Screen.height-25, Screen.width, Screen.height),  "Press: 1 for faster fireRate, 2 for speed burst and 3 to nuke");
	}
}








