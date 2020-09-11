    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
        {
            gameObject.transform.position += new Vector3(0, Random.Range(0.1f, 1), 0);
            gameObject.transform.eulerAngles += new Vector3(Random.Range(-360, 360), 
                                    Random.Range(-360, 360), Random.Range(-360, 360));
        }
    }

    public void SetIsDead(bool pIsDead = true)
    {
        _isDead = pIsDead;
    }
}
