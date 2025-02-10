using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(BoxCollider2D))]
	public class AutoUpdateBoxCollider : MonoBehaviour
	{
		private SpriteRenderer spriteRenderer;
		private BoxCollider2D boxCollider;

		private void Awake()
		{
			// Get references to the SpriteRenderer and BoxCollider2D components
			spriteRenderer = GetComponent<SpriteRenderer>();
			boxCollider = GetComponent<BoxCollider2D>();

			// Update the collider when the game starts
			UpdateCollider();
		}

		private void OnValidate()
		{
			// Ensure the collider updates when changes are made in the editor
			if (spriteRenderer != null && boxCollider != null)
			{
				UpdateCollider();
			}
		}

		private void UpdateCollider()
		{
			// Check if the sprite is not null
			if (spriteRenderer.sprite != null)
			{
				// Get the size of the sprite
				Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

				// Log the sprite size for debugging
				Debug.Log("Sprite Size: " + spriteSize);

				// Set the size of the BoxCollider2D to match the sprite
				boxCollider.size = spriteSize;

				// Log the collider size for debugging
				Debug.Log("Collider Size: " + boxCollider.size);

				// Adjust the offset if necessary (optional)
				boxCollider.offset = Vector2.zero;
			}
			else
			{
				Debug.LogWarning("Sprite is null. No collider update performed.");
			}
		}

		// Optional: If you want to update the collider in real-time during play mode
		private void Update()
		{
			if (spriteRenderer.sprite != null)
			{
				UpdateCollider();
			}
		}
	}

	Rigidbody2D rb;
	float speed;
	bool facingRight;
	private bool Jumped;
	public bool isGrounded;

	void Start () {
		speed = 5f;
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}
	void update()
	{
		if (Input.GetKey (KeyCode.Space) || (Input.GetKey (KeyCode.UpArrow)))
		{
			Jumped = true;
		}
	}
	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetKey (KeyCode.Space)))
		{
			rb.AddForce (Vector2.up * 350);
		}

     	float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);

		if (move > 0 && !facingRight) {
		flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}



		if(Jumped && isGrounded)
		{
			rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
			Jumped = false;
			isGrounded = true;
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}




	}


		
			
		













//if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.A))
//{
//transform.localScale = new Vector3 (2,2,1);
//facingRight = true;
//	}
//else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.D))
//	{
//		transform.localScale = new Vector3 (-2,2,1);
//		facingRight = false;
//	}
//public class AutoAdjustCapsuleCollider : MonoBehaviour
//{
//	private CapsuleCollider2D capsuleCollider;
//	private SpriteRenderer spriteRenderer;

//	void Start ()
//	{
//		capsuleCollider = GetComponent<CapsuleCollider2D> ();
//		spriteRenderer = GetComponent<SpriteRenderer> ();
//		UpdateCollisionSize ();
//	}
//
//	void Update ()
//	{
//		//keeps udating the sprite size as the sprites change 
//		UpdateCollisionSize ();
//	}
//
//	void UpdateCollisionSize ()
//	{
//		if (spriteRenderer.sprite != null || capsuleCollider == null)
//		{
//			Bounds bounds = spriteRenderer.sprite.bounds;
//			float width = bounds.size.x * 0.8f;
//			float height = bounds.size.y * 1f;
//			if (capsuleCollider.direction == CapsuleDirection2D.Vertical) 
//			{
//				capsuleCollider.size = new Vector2(width, height);
//
//			} 
//			else 
//			{
//				capsuleCollider.size = new Vector2(height, width);
//
//			}
//			capsuleCollider.offset = bounds.center;
//		}
//	}
//}