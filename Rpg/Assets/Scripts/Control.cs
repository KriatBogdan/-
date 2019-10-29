using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
	float Ver, Hor, Jump;
	float speed = 5;
	float jumpSpeed = 100;
	bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if(isGround)
    	{
    		Ver = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        	Hor = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        	Jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;
        	GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
    	}

        transform.Translate(new Vector3(Hor, 0, Ver));

    }
}
