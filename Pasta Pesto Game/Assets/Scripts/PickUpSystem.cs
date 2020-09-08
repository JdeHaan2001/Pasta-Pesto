using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private float _moneyTotal = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
            pickUp(10, other.gameObject);
        else if (other.tag == "PickUp1")
            pickUp(25, other.gameObject);
        else if (other.tag == "PickUp2")
            pickUp(50, other.gameObject);
    }

    private void pickUp(float pMoney, GameObject pGameObject)
    {
        _moneyTotal += pMoney;
        Destroy(pGameObject);
    }

    private void Update()
    {
        // Used for testing
        if (Input.GetKeyDown(KeyCode.C))
            _moneyTotal += 50f;
    }
}
