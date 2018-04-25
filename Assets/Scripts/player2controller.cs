using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class player2controller : MonoBehaviour {
	public float speed = 7f;
	Rigidbody rb;
	public Text countText;
	
	public Text loseText;
	public Text healthText;
	private int count;
	private int health;
	public int st=15;
	public GameObject pi1;
	public GameObject pi2;
	public GameObject pi3;
	public GameObject pi4;
	public GameObject pi5;
	public GameObject pi6;
	public GameObject pi7;
	public GameObject pi8;
	public GameObject pi9;
	public GameObject pi10;
	public GameObject pi11;
	public GameObject pi12;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		health = 5;
		
		loseText.text = "";
		pi1.SetActive (false);
		pi2.SetActive (false);
		pi3.SetActive (false);
		pi4.SetActive (false);
		pi5.SetActive (false);
		pi6.SetActive (false);
		pi7.SetActive (false);
		pi8.SetActive (false);
		pi9.SetActive (false);
		pi10.SetActive (false);
		pi11.SetActive (false);
		pi12.SetActive (false);
		togglevisible ();
		SetCountText ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(health>0 && count<12){
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
			rb.AddForce (movement*speed);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			togglevisible ();
			count = count + 1;
			SetCountText ();

		}
		else if (other.CompareTag ("obstacle")) {
			health = health-1;
			SetCountText ();
		}
	}
	void SetCountText()
	{
		countText.text = "Count - " + count.ToString ();
		healthText.text = "Health - " + health.ToString ();
		if(count == 12)
		{
            SceneManager.LoadScene("5", LoadSceneMode.Single);
		}
		if (health == 0) 
		{
			loseText.text = "You Lose Better luck Next Time.";
		}
	}
	void togglevisible()
	{
		System.Random rnd = new System.Random ();
		int abc;
		while (true) {
			abc = rnd.Next (1,13);
			if (st == abc)
				continue;
			else
				break;
		}
		st = abc;
		if (abc == 1)
			pi1.SetActive (true);
		else if (abc == 2)
			pi2.SetActive (true);
		else if (abc == 3)
			pi3.SetActive (true);
		else if (abc == 4)
			pi4.SetActive (true);
		else if (abc == 5)
			pi5.SetActive (true);
		else if (abc == 6)
			pi6.SetActive (true);
		else if (abc == 7)
			pi7.SetActive (true);
		else if (abc == 8)
			pi8.SetActive (true);
		else if (abc == 9)
			pi9.SetActive (true);
		else if (abc == 10)
			pi10.SetActive (true);
		else if (abc == 11)
			pi11.SetActive (true);
		else if (abc == 12)
			pi12.SetActive (true);
	}

}
