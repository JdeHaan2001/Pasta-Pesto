using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodGuy : MonoBehaviour
{
    private GameObject menu;
    private ShopSystem shopSystem;
    private Animator anim;
    private AIMovement AIMove;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("UI_Shop");
        shopSystem = menu.GetComponent<ShopSystem>();
        anim = GetComponent<Animator>();
        AIMove = GetComponent<AIMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("WrongSlap"))
        {
            timer += Time.deltaTime;
            AIMove.SetMoveDirection(Vector3.zero);
            if (timer >= this.anim.GetCurrentAnimatorStateInfo(0).length)
            {
                AIMove.SetMoveDirection(new Vector3(Random.Range(-1, 2) * AIMove.Speed, 0, Random.Range(-1, 2) * AIMove.Speed));
                anim.SetBool("IsSlapped", false);
                timer = 0f;
            }
        }
    }

    public void WrongHit()
    {
        
        anim.SetBool("IsSlapped", true);
        shopSystem.SetMoneyAmount(-5f);


    }
}
