using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

    public float movementSpeed;
    public CharacterController controller;
    private Vector3 position;
    Animator animator;



	void Start ()
    {
        position = transform.position;
        animator = GetComponent<Animator>();
	}
	


	void Update ()
    {
        PlayerMovement();

	}
    



    private void PlayerMovement()
    {
        if (Input.GetMouseButton(0))
            GetPosition();

        MoveToPosition();
        PlayAttackAnimations();
    }

    private void MoveToPosition()
    {

        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * movementSpeed);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }


    private void GetPosition()
    {
            RaycastHit mouseClick;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out mouseClick, 1000))
            {
                position = new Vector3(mouseClick.point.x, mouseClick.point.y, mouseClick.point.z);
            }       
    }

    public void PlayAttackAnimations()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            animator.SetTrigger("Attack");

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            animator.SetBool("Skill", true);
        else
            animator.SetBool("Skill", false);

    }
} 
