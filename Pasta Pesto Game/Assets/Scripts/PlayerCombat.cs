using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
<<<<<<< Updated upstream
    
=======
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;

>>>>>>> Stashed changes
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }

    private void attack()
    {
<<<<<<< Updated upstream
        
        
=======
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().SetIsDead();
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void handleEnemyDeath(Collider pEnemy)
    {
        //pEnemy.transform.position.y += .5f;
        //pEnemy.transform.eulerAngles = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
>>>>>>> Stashed changes
    }
}
