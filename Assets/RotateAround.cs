using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public GameObject target;

	Vector3 center;


	// Use this for initialization
	void Start () {

		center = target.transform.position;
	}


	// Update is called once per frame
	void Update () {

		transform.RotateAround (center, Vector3.up, 10 * Time.deltaTime);

	}
}