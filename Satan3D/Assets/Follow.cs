using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	//public float speed;
	private GameObject player;
	bool isFollowing;
	Vector3 direction;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		isFollowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		direction = player.transform.position - this.gameObject.transform.position;
		Vector3 speed = (player.GetComponent<SphereMove> ().getSpeed ());
		//transform.position = Vector3.Lerp (transform.position, transform.TransformPoint (Vector3.Normalize(direction)), 2f * Time.deltaTime);
		if (isFollowing) {
			transform.position = Vector3.Lerp (transform.position, transform.TransformPoint (Vector3.Scale (Vector3.Normalize (direction), speed)), 10f * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag ("Player")) {
			player.GetComponent<SphereMove>().drop();
		}
	}

	public void follow(){
		isFollowing = true;
	}

	public void unfollow(){
		isFollowing = false;
	}
}



