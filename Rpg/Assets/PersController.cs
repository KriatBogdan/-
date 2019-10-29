using UnityEngine;
using System.Collections;

public class PersController : MonoBehaviour {

	float speed =100f;
	float gravity = 20f;

	Vector3 direction;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		if (controller.isGrounded) {
			direction = new Vector3 (x, 0f, z);
			direction = transform.TransformDirection (direction) * speed;
		}

		direction.y -= gravity * Time.deltaTime;
		controller.Move (direction * Time.deltaTime);
	
	}
}
