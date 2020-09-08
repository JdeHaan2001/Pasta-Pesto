using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private float _moneyTotal = 0f;
    public GameObject UI;
    ShopSystem shop;

    void Awake()
    {
        shop = UI.GetComponent<ShopSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            pickUp(10, other.gameObject);
            Debug.Log("Picked up an object worth: 10 points");
        }
        else if (other.tag == "PickUp1")
        {
            pickUp(25, other.gameObject);
            Debug.Log("Picked up an object worth: 10 points");
        }
        else if (other.tag == "PickUp2")
        {
            pickUp(50, other.gameObject);
            Debug.Log("Picked up an object worth: 10 points");
        }
    }

    private void pickUp(float pMoney, GameObject pGameObject)
    {
        _moneyTotal += pMoney;
        Destroy(pGameObject);
    }

    void Update()
    {
        // Testing purpose: Add money for testing
        if (Input.GetKey(KeyCode.C)) _moneyTotal += 1000f;
        //if (Input.GetKeyDown(KeyCode.C)) moneyCount += 10f;


        if (shop != null)
        SetPlayerMoney(_moneyTotal);
    }


    // A simple getter-function to get PlayerMoney.
    public float GetPlayerMoney()
    {
        _moneyTotal = shop.GetMoney();
        return _moneyTotal;
    }

    // A simple setter-function to set PlayerMoney.
    public void SetPlayerMoney(float pMoney)
    {
        _moneyTotal = pMoney;
    }
}
