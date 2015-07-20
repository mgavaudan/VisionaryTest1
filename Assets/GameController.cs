using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject spawn;

	void Start () {
		GameObject.Instantiate (player);
		GameObject.Instantiate (spawn);
	}

	void Update () {
	
	}
}
