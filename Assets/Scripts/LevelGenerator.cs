using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject level;
	public GameObject player;
	CharacterController controller;

	Vector3 yDisplacement = new Vector3(0, 10f);
	bool going;
	bool done;

	void Awake()
	{
		controller = player.GetComponent<CharacterController> ();
	}

	void Start() 
	{
		GameObject instance = GameObject.Instantiate (level, player.transform.position, Quaternion.identity) as GameObject;
		instance.transform.parent = this.transform;
	}

	void Update()
	{
		going = controller.velocity.y < -20f;
		//done = controller.isGrounded;

		manageLevels ();

		if (controller.isGrounded)
			done = false;
	}

	void manageLevels()
	{
		if (going && !done) {
			killChildren ();
			createNew (player.transform.position);
			done = true;
		}			
	}

	void createNew(Vector3 position)
	{
		GameObject instance = GameObject.Instantiate (level, position - yDisplacement, Quaternion.identity) as GameObject;
		instance.transform.parent = this.transform;
	}

	void killChildren()
	{
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}
	}
}
