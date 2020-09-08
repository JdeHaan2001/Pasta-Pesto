using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    private GameObject _menu;

    [SerializeField]
    private const int _maxPickUpAmount = 10;
    [SerializeField]
    private int _currentPickUpAmount = 0;

    private void Awake()
    {
        _menu = GameObject.Find("UI_Shop");
    }

    private void OnTriggerEnter(Collider other)
    {
        handlePickUpTags(other);
        
    }
    private void OnTriggerStay(Collider other)
    {
        handleTrashCan(other);
    }
    private void handleTrashCan(Collider other)
    {
        if (other.tag == "Trashcan" && Input.GetKeyDown(KeyCode.E))
        {
            _currentPickUpAmount = 0;
        }
    }

    private void handlePickUpTags(Collider other)
    {
        if (other.tag == "PickUp")
        {
            pickUp(10, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp1")
        {
            pickUp(25, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp2")
        {
            pickUp(50, other.gameObject);
            _currentPickUpAmount++;
        }
    }

    private void pickUp(float pMoney, GameObject pGameObject)
    {
        _menu.GetComponent<ShopSystem>().SetMoneyAmount(pMoney);
        Destroy(pGameObject);
    }
}