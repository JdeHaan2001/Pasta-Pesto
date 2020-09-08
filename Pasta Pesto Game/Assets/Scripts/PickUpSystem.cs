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



//public class PickUpSystem : MonoBehaviour
//{
//    [SerializeField]
//    private float _moneyTotal = 0f;
//    private GameObject _UIShop;

//    private void Awake()
//    {
//        _UIShop = GameObject.Find("UI_Shop");
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "PickUp")
//            pickUp(10, other.gameObject);
//        else if (other.tag == "PickUp1")
//            pickUp(25, other.gameObject);
//        else if (other.tag == "PickUp2")
//            pickUp(50, other.gameObject);
//    }

//    private void pickUp(float pMoney, GameObject pGameObject)
//    {
//        //_moneyTotal += pMoney;
//        _UIShop.GetComponent<ShopSystem>().SetMoney(pMoney);
//        Destroy(pGameObject);
//    }

//    private void Update()
//    {
//        // Used for testing
//        if (Input.GetKey(KeyCode.C))
//            _moneyTotal += 1000f;
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//<<<<<<< HEAD
//=======
//using UnityEngine.UI;
//>>>>>>> Reinier

//public class PickUpSystem : MonoBehaviour
//{
//    [SerializeField]
//    private float _moneyTotal = 0f;
//<<<<<<< HEAD
//=======
//    public GameObject UI;
//    ShopSystem shop;

//    void Awake()
//    {
//        shop = UI.GetComponent<ShopSystem>();
//    }
//>>>>>>> Reinier

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "PickUp")
//<<<<<<< HEAD
//            pickUp(10, other.gameObject);
//        else if (other.tag == "PickUp1")
//            pickUp(25, other.gameObject);
//        else if (other.tag == "PickUp2")
//            pickUp(50, other.gameObject);
//=======
//        {
//            pickUp(10, other.gameObject);
//            Debug.Log("Picked up an object worth: 10 points");
//        }
//        else if (other.tag == "PickUp1")
//        {
//            pickUp(25, other.gameObject);
//            Debug.Log("Picked up an object worth: 10 points");
//        }
//        else if (other.tag == "PickUp2")
//        {
//            pickUp(50, other.gameObject);
//            Debug.Log("Picked up an object worth: 10 points");
//        }
//>>>>>>> Reinier
//    }

//    private void pickUp(float pMoney, GameObject pGameObject)
//    {
//        _moneyTotal += pMoney;
//        Destroy(pGameObject);
//    }

//<<<<<<< HEAD
//    private void Update()
//    {
//        // Used for testing
//        if (Input.GetKeyDown(KeyCode.C))
//            _moneyTotal += 50f;
//=======
//    void Update()
//    {
//        // Testing purpose: Add money for testing
//        if (Input.GetKey(KeyCode.C)) _moneyTotal += 1000f;
//        //if (Input.GetKeyDown(KeyCode.C)) moneyCount += 10f;


//        if (shop != null)
//        SetPlayerMoney(_moneyTotal);
//    }


//    // A simple getter-function to get PlayerMoney.
//    public float GetPlayerMoney()
//    {
//        _moneyTotal = shop.GetMoney();
//        return _moneyTotal;
//    }

//    // A simple setter-function to set PlayerMoney.
//    public void SetPlayerMoney(float pMoney)
//    {
//        _moneyTotal = pMoney;
//>>>>>>> Reinier
//    }
//}
