using UnityEngine;
using System.Collections;

public class SphereMove : MonoBehaviour {

	// Use this for initialization
	private Rigidbody rb;
	public float speed;
	GameObject cube;
	GameObject pig;
	GameObject held = null;
	bool isHolding = false;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		cube = GameObject.Find ("Cube");
		pig = GameObject.Find ("Pig");
		//splane = GameObject.Find ("SPlane");
	}
	

	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.UpArrow)){ transform.position = Vector3.Lerp(transform.position,transform.TransformPoint(Vector3.forward),10f* Time.deltaTime); }
		
		if (Input.GetKey(KeyCode.DownArrow)){ transform.position = Vector3.Lerp(transform.position, transform.TransformPoint (Vector3.back),10f* Time.deltaTime); }
		
		if (Input.GetKey(KeyCode.LeftArrow)){ transform.position = Vector3.Lerp(transform.position,transform.TransformPoint(Vector3.left),10f* Time.deltaTime); }
		
		if (Input.GetKey(KeyCode.RightArrow)){ transform.position = Vector3.Lerp(transform.position,transform.TransformPoint(Vector3.right),10f* Time.deltaTime); }


	}
	/*(void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}*/

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup") && !isHolding){
			//other.gameObject.SetActive(false);
			cube.transform.position = transform.position;
			cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.TransformPoint(Vector3.back), 5f);
			cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.TransformPoint(Vector3.up), 15f);

			cube.transform.parent = transform;
			isHolding = true;
			held = cube;
		}

		if (other.gameObject.CompareTag ("Pig") && !isHolding) {
			pig.transform.position = transform.position;
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.forward), 5f);
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.up), 15f);
			
			pig.transform.parent = transform;
			isHolding = true;
			held = pig;
		}

		if (other.gameObject.CompareTag ("Pentagon") && isHolding) {
			held.SetActive (false);
			held = null;
			isHolding = false;
		}

		/*if (other.gameObject.name == "Capsule") {
			this.gameObject.SetActive (false);
		}*/

		//check collision of Player and Capsule and if Player is holding pig object
		//might want to change this so that it works for all other objects when we get there
		if(other.gameObject.CompareTag("Capsule") && isHolding){
			//Vector3 downTrans = new Vector3 ();
			held.transform.position = transform.position;
			held.transform.position = Vector3.Lerp(held.transform.position, held.transform.TransformPoint(Vector3.zero), 5f);
			held.transform.parent = null;
			isHolding = false;
			held = null;
			//pig.transform.DetachChildren();
			//pig.transform.parent = splane.transform;

		}

		//collision with other objects(any other object not just pig) followed by a collision of capsule seems to break the game
		//collision with other objects other than pig makes our player object get stuck with that object

	}
}

