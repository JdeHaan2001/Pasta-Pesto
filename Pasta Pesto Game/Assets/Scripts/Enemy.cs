    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isDead = false;
    private Rigidbody rb;
    private AISpawner AISpwn;


    public float DespawnTimer = 2f;
    public GameObject GameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        AISpwn = GameManager.GetComponent<AISpawner>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_isDead)
        {
            rb.freezeRotation = false;
            gameObject.transform.position += new Vector3(0, Random.Range(0.1f, 0.5f), 0);
            gameObject.transform.eulerAngles += new Vector3(Random.Range(-360, 360), 
                                    Random.Range(-360, 360), Random.Range(-360, 360));
            DespawnTimer -= Time.deltaTime;
            if (DespawnTimer <= 0f)
            {
                Destroy(gameObject);
                AISpwn.SetEnemyTotal();
                AISpwn.RemoveEnemyFromList(this.gameObject);
            }
        }
    }

    public void SetIsDead(bool pIsDead = true)
    {
        _isDead = pIsDead;
    }
}
