using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float WaitMoveAmount = 2f;
    public float MovingAmount = 2f;

    private float WaitMoveTimer;
    private float MovingTimer;

    private Rigidbody rb;
    private Animator anim;

    private bool _isMoving;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        WaitMoveTimer = WaitMoveAmount;
        MovingTimer = MovingAmount;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", true);
        moveDirection = new Vector3(Random.Range(-1, 2) * Speed, 0, Random.Range(-1, 2) * Speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = Quaternion.LookRotation(moveDirection);
        MovingTimer -= Time.deltaTime;
        rb.velocity = moveDirection;
        if (MovingTimer < 0f)
        {
            MovingTimer = WaitMoveAmount;
            moveDirection = new Vector3(Random.Range(-1, 2) * Speed, 0, Random.Range(-1, 2) * Speed);
        }
        #region old AI movement
        /*if (_isMoving)
        {
            MovingTimer -= Time.deltaTime;
            rb.velocity = moveDirection;

            if (MovingTimer < 0f)
            {
                _isMoving = false;
                //WaitMoveTimer = Random.Range(0f, 1f);
                WaitMoveTimer = 0f;
                anim.SetBool("IsWalking", false);
            }
        }
        else
        {
            WaitMoveTimer -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            if (WaitMoveTimer <= 0f)
            {
                _isMoving = true;
                MovingTimer = MovingAmount;

                moveDirection = new Vector3(Random.Range(-1, 2) * Speed, 0, Random.Range(-1, 2) * Speed);
                rb.rotation = Quaternion.LookRotation(moveDirection);
                anim.SetBool("IsWalking", true);
            }
        }*/
        #endregion
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }

    public void SetMoveDirection(Vector3 pMoveDirection)
    {
        moveDirection = pMoveDirection;
    }
}
