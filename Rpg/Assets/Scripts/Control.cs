using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
	float Ver, Hor, Jump;
	float Speed;
	float jumpSpeed = 100;
	bool isGround;
	public float RunSpeed = 15, StepSpeed = 3, NormalSpeed = 7;  
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
    	if (Input.GetKey(KeyCode.LeftShift))
    	{
    		Speed = RunSpeed;
    	}
    	else if (Input.GetKey(KeyCode.LeftControl))
    	{
    		Speed = StepSpeed;
    	} 
    	else
    	{
    		Speed = NormalSpeed;
    	} 
    	if(isGround)
    	{
    		Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        	Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        	Jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed;
        	GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
    	}
    	transform.Translate(new Vector3(Hor, 0, Ver));

    }
}
