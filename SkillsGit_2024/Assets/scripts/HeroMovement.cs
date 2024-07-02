using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class   HeroMovement : MonoBehaviour {

	public int Lives;
	public bool Vulnerable;

	Rigidbody2D rb;
	float speed;



	public void setLives(){
		Lives -= 1;

		if (Lives <= 0 || Vulnerable == true )
		{
			Debug.Log ("End of game");
			SceneManager.LoadScene ("Lose");
		}
	}
	void Start () {
		speed = 5.1f;
		rb = GetComponent<Rigidbody2D>();
		Lives = 2;
		Vulnerable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.AddForce (Vector2.up * 400);
		}
	}
	

		void resetPosition() 
		{
			Debug.Log("SPIKED RECEIVED!");
			transform.SetPositionAndRotation( new Vector3 (-5.58f,0.6f,0),Quaternion.identity);
		    setLives();
		}

	private void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "extraLife")
		{
			Lives += 1;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "Vulnerable")
		{
			Destroy (other.gameObject);
			Vulnerable = true;
			Debug.Log ("Vulnerable = true");
			StartCoroutine ("VulnerableDeBuff");
		}
	}
	IEnumerator VulnerableDeBuff()
		{
		yield return new WaitForSeconds (5f);
		Vulnerable = false;
		Debug.Log ("Vulnerable = false");
		StartCoroutine ("VulnerableDeBuff");
		}
}