using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
	public float gravity;
	float h,v;

	[HideInInspector] public Transform target;
	public Transform pivotTransform;

	Vector3 movement;
	Quaternion newRotation;

	Animator anim;
	CharacterController controller;

	[HideInInspector] public bool orbit, walking;

    void Awake () {

		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
    }

	void Update() 
	{
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		walking = h != 0f || v != 0f;
		orbit = h != 0f;

		CalcMovement (h, v);
		HandleRotation ();

		anim.SetBool("move", walking);

		if(!controller.isGrounded){
			movement.y -= gravity;
		}
	}

	void FixedUpdate()
	{
		controller.Move (movement * Time.deltaTime);	
	}

    void CalcMovement (float h, float v) 
	{
		movement = new Vector3 ();

		if (v != 0 || h != 0)
			movement = v * pivotForward() + h * pivotRight();
			
		movement = movement.normalized * speed;
    }

	void HandleRotation()
	{
		if (walking)
			newRotation = Quaternion.LookRotation (movement, Vector3.up);

		transform.rotation = newRotation;
	}

	Vector3 pivotForward() 
	{
		Vector3 forwardVector = pivotTransform.transform.forward;
		forwardVector.y = 0;
		return forwardVector;
	}

	Vector3 pivotRight() 
	{
		Vector3 rightVector = pivotTransform.transform.right;
		rightVector.y = 0;
		return rightVector;
	}
}