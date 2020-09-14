using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    private Animator anim;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = moveVec * Speed;
        rb.rotation = Quaternion.LookRotation(moveVec);
        if (rb.velocity != Vector3.zero)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);
    }
}
