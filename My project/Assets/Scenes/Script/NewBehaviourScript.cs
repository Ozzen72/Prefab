using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	// Start is called before the first frame update

	private Rigidbody2D rb;
	private Animator anim;
	[SerializeField] private float speed;

	private bool isGrounded;
	private float direction;
	private bool facingRight = true;
	//int nummer;
	//float kommatal;
	public void Start() {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}


	public void Update() {
        void Start()
		{
			DontDestroyOnLoad(gameObject);

		}
		void OnLevelWasLoaded(int level) => FindStartPos();

		void FindStartPos()
        {
            transform.position = GameObject.FindGameObjectWithTag("StartPos").transform.position;
        }
        direction = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
		//Hvis Jump (space) er installeret så ændre rigidbody y-velocity 
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, speed);
			anim.SetBool("isJumping", true);
		}
		//Går mod højre
		if (direction > 0 && facingRight == false)
		{
			Flip();
			//Flip player
		}

		if (direction < 0 && facingRight == true)
		{
			Flip();
		}



        if (direction > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else if (direction < 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

	private void Flip() {

		Vector3 current = gameObject.transform.localScale;
		current.x = current.x * -1;
		gameObject.transform.localScale = current;
		facingRight = !facingRight;

	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{ if (other.gameObject.CompareTag("Floor"))
		{
			isGrounded = false;
			anim.SetBool("isJumping", false);
		}
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			isGrounded = false;

            if (other.CompareTag("Collectable"))

            {
                string itemType = other.gameObject.GetComponent<Collectable>().itemType;

                print("Yey vi har samlet en Collectable af typen:" + itemType);
            }
        }
	}
	

   
}
