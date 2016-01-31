using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;

	float speed = 100;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.forward, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.forward), 10f * Time.deltaTime);
			rb.AddForce(Vector3.forward * speed);
		}
		
		if (Input.GetKey(KeyCode.DownArrow)){
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint (Vector3.Scale(Vector3.back, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint (Vector3.back), 10f * Time.deltaTime);
			rb.AddForce(Vector3.back * speed);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)){
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.left, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.left), 10f * Time.deltaTime);
			rb.AddForce(Vector3.left * speed);
		}
		
		if (Input.GetKey(KeyCode.RightArrow)){
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.right, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.right), 10f * Time.deltaTime);
			rb.AddForce(Vector3.right * speed);
		}
	
	}*/

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
}
