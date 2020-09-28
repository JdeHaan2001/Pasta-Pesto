using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;
    public GameObject player;
    public LayerMask GoodGuyLayers;

    private Animator anim;
    private GameObject menu;
    private ShopSystem shopSystem;

    private void Start()
    {
        menu = GameObject.Find("UI_Shop");
        shopSystem = menu.GetComponent<ShopSystem>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
            { 
                anim.Play("Punch", 0, 0.65f);
                attack();
            }
        }
    }

    private void attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayers);
        Collider[] hitGoodGuy = Physics.OverlapSphere(AttackPoint.position, AttackRange, GoodGuyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            shopSystem.SetMoneyAmount(6f);
            shopSystem.SetTotalEarned(6f);
            FindObjectOfType<AudioManager>().Play("Slap");
            enemy.GetComponent<Enemy>().SetIsDead();
        }
        foreach (Collider GoodGuy in hitGoodGuy)
        {
            FindObjectOfType<AudioManager>().Play("Slap");
            GoodGuy.GetComponent<GoodGuy>().WrongHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
