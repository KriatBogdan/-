using UnityEngine;
using System.Collections;

public class PersController : MonoBehaviour {

	float speed =5f;
	float gravity = 20f;

	
    float tiltAngle = 60.0f;

	Vector3 direction;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		Quaternion rotation = Quaternion.Euler(0, 30, 0);
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

		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

		
        // Rotate the cube by converting the angles into a quaternion.
        

        // Dampen towards the target rotation
		
	
	}
}
