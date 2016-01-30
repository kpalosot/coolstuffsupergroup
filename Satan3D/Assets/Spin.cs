using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float speed = 50f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back, speed);
		transform.Rotate(Vector3.right, speed);
	}
}
