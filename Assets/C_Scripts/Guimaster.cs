using UnityEngine;
using System.Collections;

public class Guimaster : MonoBehaviour {

	public int flag = 0;

	void Update(){
		if (Input.GetKeyUp ("r")) {  
			Application.LoadLevel (0);  
		} 
		if (Input.GetKeyUp ("q")) { 
			Application.Quit ();
		}
	
	}

	void OnGUI(){
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 20;
		myStyle.normal.textColor= Color.white;
		if (flag==1) {
			GUI.Label( new Rect(150, Screen.height/2, Screen.width, Screen.height), "You win! Press R to restart or Q to quit!", myStyle);
		} 
		if (flag==2) {
			GUI.Label( new Rect(150, Screen.height/2, Screen.width, Screen.height), "Game Over! Press R to restart or Q to quit!", myStyle);
		} 
	}
}
