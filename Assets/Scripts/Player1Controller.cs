using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Player1Controller : MonoBehaviour {
	public float speed = 7f;
	Rigidbody rb;
	public Text countText;
	

	private int count;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;


		


	}

	// Update is called once per frame
	void FixedUpdate () {
		if(count<12){
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

	}
	void SetCountText()
	{
		countText.text = "Count - " + count.ToString ();

		if (count == 12) {
			
			SceneManager.LoadScene ("2",LoadSceneMode.Single);

		}
	}

}
