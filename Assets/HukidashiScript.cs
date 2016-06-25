using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HukidashiScript : MonoBehaviour {

	public Camera camera;
	//public GameObject target; 吹き出しをつける対象にスクリプトをつけるように仕様変更

	public float baseLength;
	public Vector3 offset;

	public Vector3 baseSize = new Vector3(-1.5f,1.5f);
	Vector3 _baseSize;

	public string canvasName = "Canvas";

	GameObject canvas;
	public GameObject PopUpPrefab;
	GameObject popUp;

	RectTransform rectTransform;

	Text text;

	// Use this for initialization
	void Awake () {



		popUp = GameObject.Instantiate (PopUpPrefab);

		if(camera ==null){
			camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		}
		rectTransform = popUp.GetComponent<RectTransform> ();
		rectTransform.localScale = baseSize;

		float ratio = baseLength / Vector3.Magnitude (camera.gameObject.transform.position - gameObject.transform.position);
		rectTransform.position = camera.WorldToScreenPoint(gameObject.transform.position) + offset*ratio;
		popUp.SetActive (true);
		text = popUp.GetComponentInChildren<Text> ();
		popUp.transform.parent = GameObject.Find (canvasName).transform;


	
	}
	
	// Update is called once per frame
	void OnGUI (){

		float ratio = baseLength / Vector3.Magnitude (camera.gameObject.transform.position - gameObject.transform.position);

		Debug.Log (ratio);

		rectTransform.position = camera.WorldToScreenPoint(gameObject.transform.position) + offset*ratio;

		rectTransform.localScale = baseSize * ratio;
	}

	public void ChangeText(string newText){

		text.text = newText;

	}

}
