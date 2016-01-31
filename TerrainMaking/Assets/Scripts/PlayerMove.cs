using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;

	GameObject pig;
	GameObject pigBaddy;

	public GameObject[] Baddies;
	public float[] Distances;

	GameObject held;

	float speed = 100;

	float distance;
	float respawnTime;

	bool isHolding;
	bool canPickup;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		pig = GameObject.Find ("Pig");
		pigBaddy = GameObject.Find ("PigBaddy");

		Baddies = new GameObject[10];
		Distances = new float[10];
		Baddies[0] = pigBaddy; 


		held = null;

		isHolding = false;
		canPickup = true;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void FixedUpdate ()
	{
		var i = 0;
		foreach (GameObject baddy in Baddies) {
			canPickup = canPickup && (Vector3.Distance (baddy.transform.position, transform.position) < 3f);
			Distances[i] = (Vector3.Distance (pigBaddy.transform.position, transform.position));
			if(Distances[i] < 3f && canPickup){
				canPickup = true;
			}else{
				canPickup = false;
			}

			i++;	


		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	void LateUpdate(){
		canPickup = true;
	}

	void OnTriggerEnter(Collider thing){

		if (thing.gameObject.CompareTag ("Pig") && !isHolding) {
			pig.transform.position = transform.position;
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.forward), 5f);
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.up), 15f);

			pig.transform.parent = transform;

			held = pig;
			isHolding = true;
		}
		if (thing.gameObject.CompareTag ("Baddy")) {
			drop();
		}
	}

	public void drop(){
		if (isHolding) {
			Debug.Log ("DRRRROP");
			held = null;
			isHolding = false;
		} else {

		}
	}
}
