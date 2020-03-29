using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public float speed = 3f;
	private float scaleRotation = 3f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotateDirection = Vector3.zero;
	CharacterController controller;
	private float smooth = 0.1f;
	private float rotateY = 0;


    // Update is called once per frame
    void Update()
    {

    	

        moveDirection = Input.GetAxis("Vertical") * transform.forward;
        moveDirection *= speed*Time.deltaTime;
        //controller.Move(moveDirection*Time.deltaTime);   
        
        Debug.Log(moveDirection);
        transform.position += moveDirection;

        rotateY = Input.GetAxis("Horizontal") * scaleRotation;
        //Debug.Log(rotateY * scaleRotation);
        Debug.Log(scaleRotation);
       	transform.Rotate(0, rotateY, 0);

    }
}
