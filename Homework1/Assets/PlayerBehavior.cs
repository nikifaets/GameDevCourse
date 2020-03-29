using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public float speed = 3f;
	private float scaleRotation = 3f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotateDirection = Vector3.zero;
	CharacterController controller;
	private float rotateY = 0;
    public float gravity = 10f;
    private Vector3 fallingVelocity = new Vector3();
    private int groundCount = 0; 
    private float maxGroundAngle = 120f;
    public float jumpHeight = 0.01f;

    // Update is called once per frame
    void Update()
    {

    	if(groundCount < 1) fallingVelocity.y -= gravity * Time.deltaTime*0.1f;
        else
        {
            fallingVelocity.y = 0;
            if (Input.GetButtonUp("Jump"))
            {
                fallingVelocity.y += jumpHeight;
            }
        }


        moveDirection = Input.GetAxis("Vertical") * transform.forward;
        moveDirection *= speed*Time.deltaTime;
        moveDirection += fallingVelocity;
        
        transform.position += moveDirection;

        rotateY = Input.GetAxis("Horizontal") * scaleRotation;

       	transform.Rotate(0, rotateY, 0);

    }


    void OnCollisionEnter(Collision other)
    {
        if(isOnGround())
        {
            groundCount += 1;
        }
        Debug.Log(345);
    }

    void OnCollisionExit(Collision other)
    {
        if(isOnGround()) groundCount -= 1;
    }
 

    private bool isOnGround()
    {

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {

            Collider collider = hit.collider;
            float angle = Vector3.Angle(Vector3.down, collider.gameObject.transform.forward);
            
            return angle < maxGroundAngle;
        }

        return false;
    }

}
