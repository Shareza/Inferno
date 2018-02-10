using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {


    public float speed;
    public float range;
    public CharacterController controller;
    //public Transform player;
    public GameObject player;
    public Animator animator;
    
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        Chase();
        
        if(InRange())
        {
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Attack");  
        }
	}

    bool InRange()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Chase()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(player.transform.position);
        controller.SimpleMove(transform.forward * speed);
        animator.SetBool("IsWalking", true);

    }
}
