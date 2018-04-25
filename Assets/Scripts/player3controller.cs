using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class player3controller : MonoBehaviour {
	public float speed = 7f;
	Rigidbody rb;
	public Text countText;
	
	public Text loseText;
	public Text healthText;
	private int count;
	private int health;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		health = 5;

		
		loseText.text = "";

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
						SceneManager.LoadScene ("4",LoadSceneMode.Single);
		}
		if (health == 0) 
		{
			loseText.text = "You Lose Better luck Next Time.";
		}
	}

}
