using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {


	void Start () {
	
		StartCoroutine (DestructAut());
	}

	IEnumerator DestructAut(){
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}
}
