using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static int flag;

	public static int Flag {
		set{
			flag = value;
		}
	}

	public GameObject player;
	public GameObject spawn;

	void Awake(){
		flag = 0;
	}

	void Start(){
	
		// Null checks
		if (!player) {
			player = GameObject.Find("Player");
		}
		if (!spawn) {
			spawn = GameObject.Find("Spawn");
		}
	
	}

	void Update(){

		//restart
		if (Input.GetKeyUp ("r")) {  
			Application.LoadLevel (0);  
		} 
		// quit
		if (Input.GetKeyUp ("q")) { 
			Application.Quit ();
		}

		 ExplosionMaster ();
	
	}

	void ExplosionMaster(){

		if (flag==1) {
			ParticleSystem exp = spawn.GetComponent<ParticleSystem>();
			exp.Play();
			Destroy(spawn, exp.duration);
			Destroy(player, exp.duration);
			flag=3;

		} 
		if (flag==2) {
			ParticleSystem exp = player.GetComponent<ParticleSystem>();
			exp.Play ();
			Destroy(player, exp.duration);
			flag = 4;
		} 

	}

	void OnGUI(){

		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = Screen.height/20;
		myStyle.normal.textColor= Color.white;
		if (flag==3) {
			GUI.Label( new Rect(Screen.width/3.5f, Screen.height/2, Screen.width, Screen.height), "You win! Press R to restart or Q to quit!", myStyle);
		} 
		if (flag==4) {
			GUI.Label( new Rect(Screen.width/3.5f, Screen.height/2, Screen.width, Screen.height), "Game Over! Press R to restart or Q to quit!", myStyle);
		} 
	}
}
