using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	[Range(0, 5)]
	private float moveSpeed = 2;

	[SerializeField]
	[Range(0.1f, 2)]
	public float gravity = 0.5f;

	private bool isCrouching = false;
	private bool isJumping = false;
	private readonly float movementThreshold = 0.01f;
	private Vector2 velocity = Vector2.zero;

	[SerializeField]
	private KeyCode jumpKey = KeyCode.W;

	[SerializeField]
	private KeyCode crouchKey = KeyCode.S;

	private Animator animator;
	private new Rigidbody2D rigidbody;

	private RuntimeAnimatorController BigMario;

	void Start() {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		BigMario = Resources.Load<RuntimeAnimatorController>("MarioBig");
	}

	void Update() {
		isCrouching = Input.GetKey(crouchKey);
		if (!isJumping) {
			animator.SetBool("IsCrouching", isCrouching);
			if (isCrouching) {
				return;
			}
		}

		velocity.x = Input.GetAxis("Horizontal");
		animator.SetFloat("HorizontalMovement", Abs(velocity.x));

		if (Abs(velocity.x) > movementThreshold) {
			transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
		}

		if (!isJumping && Input.GetKeyDown(jumpKey)) {
			velocity.y = 1;
			isJumping = true;
			animator.SetBool("IsJumping", true);
		}

		rigidbody.MovePosition(rigidbody.position + velocity * moveSpeed * Time.deltaTime);

		if (isJumping) {
			velocity.y -= gravity * Time.deltaTime;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Floor")) {
			isJumping = false;
			animator.SetBool("IsJumping", false);
			velocity.y = 0;
		}

		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Mushroom")){

			//Animator animator = GetComponent<Animator>();
			//animator.runtimeAnimatorController = BigMario;
			animator.Play("Buff");
		}
	}

	private void OnBuffFinished(){

		animator.runtimeAnimatorController= BigMario;
	}



	


	private void OnCollisionExit2D(Collision2D collision) {
		
		if (collision.gameObject.CompareTag("Floor") && IsOnFloor(collision.collider)){

			isJumping = true;
		}
	}

	private bool IsOnFloor(Collider2D collider){

		RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right);
		RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left);

		if (hit_right.collider == collider || hit_left.collider == collider){

			return false;
		}

		return true;

	}
}
