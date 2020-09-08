using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    private GameObject _menu;

    private void Awake()
    {
        _menu = GameObject.Find("UI_Shop");
    }

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
        _menu.GetComponent<ShopSystem>().SetMoneyAmount(pMoney);
        Destroy(pGameObject);
    }
}