using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    private GameObject _menu;
    private ShopSystem shopSystem;

    [SerializeField]
    private const int _maxPickUpAmount = 10;
    [SerializeField]
    private int _currentPickUpAmount = 0;

    private float plasticValue = 1f;

    private void Awake()
    {
        _menu = GameObject.Find("UI_Shop");
        shopSystem = _menu.GetComponent<ShopSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_currentPickUpAmount < _maxPickUpAmount)
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
            shopSystem.SetMoneyAmount(plasticValue * _currentPickUpAmount);
            _currentPickUpAmount = 0;
        }
    }

    private void handlePickUpTags(Collider other)
    {
        if (other.tag == "PickUp")
        {
            pickUp(plasticValue, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp1")
        {
            pickUp(plasticValue * 2, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp2")
        {
            pickUp(plasticValue * 5, other.gameObject);
            _currentPickUpAmount++;
        }
    }

    private void pickUp(float pMoney, GameObject pGameObject)
    {
        Destroy(pGameObject);
    }
}