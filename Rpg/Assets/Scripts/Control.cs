using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
	public GameObject cam;

	Quaternion StartingRotation;

	float Ver, Hor, Jump, RotVer, RotHor;
	float Speed;
	float jumpSpeed = 100;
	bool isGround;
	public float RunSpeed = 15, StepSpeed = 3, NormalSpeed = 7,sensitivity = 5;  
    // Start is called before the first frame update
    void Start()
    {
        StartingRotation = transform.rotation;
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
    	RotHor += Input.GetAxis("Mouse X");
    	RotVer += Input.GetAxis("Mouse Y");

    	RotVer = Mathf.Clamp(RotVer, -60, 60);

    	Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);
    	Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);

    	cam.transform.rotation = StartingRotation * RotY * RotX;
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
