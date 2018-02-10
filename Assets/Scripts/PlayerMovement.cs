using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    //
    Vector3 forward, right;
    //
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        //
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //
    }

    void Update()
    {
        //float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");

        //ControllPlayer(moveHorizontal, moveVertical);
        //Animating(moveVertical, moveHorizontal);

        //
        if (Input.anyKey)
            Move();
        Animating();
        //
    }
    //
    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    //
    void Animating()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.Mouse1))
            anim.SetBool("Skill", true);
        else
            anim.SetBool("Skill", false);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            anim.SetTrigger("Attack");
    }

    void ControllPlayer(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

}
