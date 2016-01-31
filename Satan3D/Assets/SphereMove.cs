using UnityEngine;
using System.Collections;

public class SphereMove : MonoBehaviour {

	// Use this for initialization
	private Rigidbody rb;
	//public float speed;
	GameObject cube;
	GameObject pig;
	GameObject player;
	GameObject enemy;
	GameObject held = null;
	GameObject text;
	GameObject canvasScript;
	Vector3 [] allSpeeds = new Vector3[4];
	int curSpeedInd;

	
	bool isHolding = false;
	bool canPickup = true;

	public int hp;
	
	float distance;
	float respawnTime;
	// Use this for initialization
	void Start () {
		cube = GameObject.Find ("Cube");
		pig = GameObject.Find ("Pig");
		player = GameObject.Find("Player");
		enemy = GameObject.Find("Capsule");
		canvasScript = GameObject.Find ("Canvas");
		hp = 1;
		//speed = 1;
		allSpeeds[0] = new Vector3 (1, 1, 1);
		allSpeeds[1] = new Vector3 (1.5f, 1, 1.5f);
		allSpeeds[2] = new Vector3 (2, 1, 2);
		allSpeeds[3] = new Vector3 (2.5f, 1, 2.5f);
		curSpeedInd = 0;
		canvasScript.GetComponent<CanvasScript>().setHp ();
	}
	

	
	// Update is called once per frame
	void Update () {
		if (hp == 0) {
			transform.DetachChildren();
			this.gameObject.SetActive(false);
		}

		distance  = Vector3.Distance(player.transform.position, enemy.transform.position);	
		canPickup = ((distance >= 1f) && !isHolding);

	 	if (Input.GetKey(KeyCode.UpArrow)){
			transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.forward, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.forward), 10f * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position = Vector3.Lerp(transform.position, transform.TransformPoint (Vector3.Scale(Vector3.back, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint (Vector3.back), 10f * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.left, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.left), 10f * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.Scale(Vector3.right, allSpeeds[curSpeedInd])), 10f * Time.deltaTime);
			//transform.position = Vector3.Lerp(transform.position, transform.TransformPoint(Vector3.right), 10f * Time.deltaTime);
		}


	}

	void FixedUpdate (){
		respawnTime -= Time.deltaTime;
		//Debug.Log (respawnTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup") && canPickup){
			cube.transform.position = transform.position;
			cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.TransformPoint(Vector3.back), 5f);
			cube.transform.position = Vector3.Lerp(cube.transform.position, cube.transform.TransformPoint(Vector3.up), 15f);

			cube.transform.parent = transform;
			isHolding = true;
			held = cube;

			cube.GetComponent<Run>().hold();
		}

		if (other.gameObject.CompareTag ("Pig") && canPickup) {
			pig.transform.position = transform.position;
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.forward), 5f);
			pig.transform.position = Vector3.Lerp(pig.transform.position, pig.transform.TransformPoint(Vector3.up), 15f);
			
			pig.transform.parent = transform;
			isHolding = true;
			held = pig;

			pig.GetComponent<Run>().hold();
		}

		if (other.gameObject.CompareTag ("Pentagon") && isHolding) {
			held.SetActive (false);
			held = null;
			isHolding = false;
			hp++;
			canvasScript.GetComponent<CanvasScript>().setHp ();
			curSpeedInd++;

		}

		/*if(other.gameObject.CompareTag("Capsule") && isHolding){
		
			//Vector3 downTrans = new Vector3 ();
			held.transform.position = transform.position;
			held.transform.position = Vector3.Lerp(held.transform.position, held.transform.TransformPoint(Vector3.zero), 5f);
			held.transform.parent = null;
			isHolding = false;
			held = null;
			//pig.transform.DetachChildren();
			//pig.transform.parent = splane.transform;

		}*/

	}
	public void drop(){
		if (isHolding){
			held.transform.position = transform.position;
			held.transform.position = Vector3.Lerp(held.transform.position, held.transform.TransformPoint(Vector3.zero), 5f);
			held.transform.parent = null;
			held.GetComponent<Run>().drop ();

			isHolding = false;
			held = null;

			respawnTime = 2f;

		}
		if (!isHolding) {
			if(respawnTime <= 0){
				hp--;
				canvasScript.GetComponent<CanvasScript>().setHp ();

			}
		}
	}
	public string getHp(){
		return hp.ToString ();
	}

	public Vector3 getSpeed(){
		return allSpeeds[curSpeedInd];
	}
	
}

