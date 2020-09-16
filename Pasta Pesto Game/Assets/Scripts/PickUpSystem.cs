using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    private GameObject _menu;
    private ShopSystem shopSystem;

    [SerializeField]
    private int _maxPickUpAmount = 10;
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
            FindObjectOfType<AudioManager>().Play("ThrowTrash");
            shopSystem.SetMoneyAmount(plasticValue * _currentPickUpAmount);
            _currentPickUpAmount = 0;
        }
    }

    private void handlePickUpTags(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("PickUp");
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
        else if (other.tag == "PickUp3")
        {
            pickUp(plasticValue * 8, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp4")
        {
            pickUp(plasticValue * 10, other.gameObject);
            _currentPickUpAmount++;
        }
        else if (other.tag == "PickUp5")
        {
            pickUp(plasticValue * 15, other.gameObject);
            _currentPickUpAmount++;
        }
    }

    private void pickUp(float pMoney, GameObject pGameObject)
    {
        Destroy(pGameObject);
    }


    public void SetPlasticWorth(float pValue)
    {
        plasticValue = pValue;
    }

    public float GetPlasticWorth()
    {
        return plasticValue;
    }

    public void SetMaxCarry(int pMax)
    {
        _maxPickUpAmount = pMax;
    }

    public int GetMaxCarry()
    {
        return _maxPickUpAmount;
    }

    public void SetCurrentCarry(int pMax)
    {
        _currentPickUpAmount = pMax;
    }

    public int GetCurrentCarry()
    {
        return _currentPickUpAmount;
    }
}