using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;

    private Animator anim;

    private void Start()
    {
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

        foreach (Collider enemy in hitEnemies)
        {
            FindObjectOfType<AudioManager>().Play("Slap");
            enemy.GetComponent<Enemy>().SetIsDead();
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
