using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasScript : MonoBehaviour {

	public GameObject player;
	public Text Text_obj;
	string hp;

	//UnityEngine.UI.Text Text;



	// Use this for initialization
	void Start () {
		//text = GameObject.Find("Text");
		player = GameObject.Find("Player");
		Text_obj = GameObject.Find ("Text").GetComponent<Text> ();
		Text_obj.text = player.GetComponent<SphereMove>().getHp();



	}

	public void setHp(){
		Text_obj.text = player.GetComponent<SphereMove>().getHp();
	}



}


