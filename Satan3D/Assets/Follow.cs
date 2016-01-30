﻿using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public float speed;
	private GameObject player;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		direction = player.transform.position - this.gameObject.transform.position;
		transform.position = Vector3.Lerp (transform.position, transform.TransformPoint (direction), 2f * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag ("Player")) {
			player.GetComponent<SphereMove>().drop();
		}
	}
}
