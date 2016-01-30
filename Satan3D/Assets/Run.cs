using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {
	public bool held, wasHeld;
	GameObject player;
	Vector3 direction;
	float distance;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		held = false;
		wasHeld = false;

	}
	
	// Update is called once per frame
	void Update () {
		distance  = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
		if (!held && wasHeld && (distance <= 10f)) {

			direction = this.gameObject.transform.position - player.transform.position;
			transform.position = Vector3.Lerp (transform.position, transform.TransformPoint (direction), 0.25f * Time.deltaTime);
		}
	}
	public void hold(){
		held = true;
		wasHeld = true;
	}
	public void drop(){
		held = false;
	}
}
