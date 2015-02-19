using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public float turnSpeed = 90f;
	float rotation = 0f;
	float rotationOffset = 0;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = Quaternion.Euler (0, rotation, 0) * movement;
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition (transform.position + movement);
	}

	/* This is implemented if using a third-person view point
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotatiion = Quaternion.LookRotation(playerToMouse);
			playerRigidBody.MoveRotation(newRotatiion);
		}
	}*/

	/** Turning for first-person
	 * 	Tyler McCreary
	 */
	void Turning()
	{
		float mouseInput = Input.GetAxis ("Mouse X") / 5f;
		if (mouseInput > 0.02f)
		{
			rotation = rotation + (Time.deltaTime * turnSpeed);
			transform.RotateAround (transform.position, transform.up, Time.deltaTime * turnSpeed);
		}
		else if (mouseInput < -0.02f)
		{
			rotation = rotation - (Time.deltaTime * turnSpeed);
			transform.RotateAround (transform.position, transform.up, Time.deltaTime * -turnSpeed);
		}

	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}
