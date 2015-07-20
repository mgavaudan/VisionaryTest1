using UnityEngine;
using System.Collections;

public class EffectsMaster : MonoBehaviour {

	public int flag;
	public GameObject player;
	public GameObject spawn;

	void Awake(){
	
		flag = 0;
	
	}

	void Update(){

		// Null checks
		if (!player) {
			GameObject.Find("Main Camera");
		}
		if (!spawn) {
			GameObject.Find("Capsule");
		}

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
			Destroy(player);
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
		myStyle.fontSize = 20;
		myStyle.normal.textColor= Color.white;
		if (flag==3) {
			GUI.Label( new Rect(Screen.width/3.5f, Screen.height/2, Screen.width, Screen.height), "You win! Press R to restart or Q to quit!", myStyle);
		} 
		if (flag==4) {
			GUI.Label( new Rect(Screen.width/3.5f, Screen.height/2, Screen.width, Screen.height), "Game Over! Press R to restart or Q to quit!", myStyle);
		} 
	}
}
