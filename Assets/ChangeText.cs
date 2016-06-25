using UnityEngine;
using System.Collections;

public class ChangeText : MonoBehaviour {

	public string newText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){

		col.gameObject.GetComponent<HukidashiScript> ().ChangeText (newText);

	}
}