using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class ShopSystem : MonoBehaviour
{
    [Tooltip("The amount of money you have")] [SerializeField] private float moneyCount = 0f;
    [Tooltip("The multiplier for upgrades")] [SerializeField] private float multiplier = 1.15f;
    private Transform shopItemTemplate;
    private Transform container;
    private Transform money;
    private Transform holding;
    private Transform holdingText;
    private PlayerMovement plMovement;
    private PickUpSystem puSystem;
    private LevelSystem lvlSystem;
    public GameObject player;


    private float shopItemHeight = 50f;
    private float valueIncrease = 0.5f;
    private float speedIncrease = 0.5f;
    private float timeDecrease = 0.125f;
    private int carryIncrease = 2;
    private int currentCarry;


    //-------------------- Product Image --------------------//
    public Sprite item1Image;
    public Sprite item2Image;
    public Sprite item3Image;
    public Sprite item4Image;
    public Sprite item5Image;

    //-------------------- Product Name --------------------//
    private string item1Name = "It's rewind time";
    private string item2Name = "Gotta go fast";
    private string item3Name = "Increased Pockets";
    private string item4Name = "Advertisements";
    private string item5Name = "Plastic Monopoly";

    //-------------------- Shop price --------------------//
    private float item1Price = 30f;
    private float item2Price = 10f;
    private float item3Price = 25f;
    private float item4Price = 100f;
    private float item5Price = 15f;

    void Awake()
    {
        // Assign the corresponding gameObject to the Transform variables.
        money = transform.Find("money");
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        holding = transform.Find("holdingItems");
        holdingText = holding.Find("holdingText");
        puSystem = player.GetComponent<PickUpSystem>();
        plMovement = player.GetComponent<PlayerMovement>();
        lvlSystem = player.GetComponent<LevelSystem>();

        // Start game with 0 "money"
        moneyCount = 0;
    }

    private void Start()
    {
        // Add an item to the list of shopitems -> Image, Name, Cost, Position
        //-----------------------------------------------------------------------------------------
        // Simply add a new item by adding in a new line below, use the following template
        // TEMPLATE: createItemSlot(item[X]Image, item[X]Name, item[X]Price.ToString(), [next number]);
        // Make sure to also add the image above at (//-------------------- Product Image --------------------//)
        // Make sure to also add the price above at (//-------------------- Shop price --------------------//)
        // Make sure to also add the index below at (//-------------------- Button-usability --------------------//)
        //-----------------------------------------------------------------------------------------
        createItemSlot(item1Image, item1Name, item1Price.ToString(), 1);
        createItemSlot(item2Image, item2Name, item2Price.ToString(), 2);
        createItemSlot(item3Image, item3Name, item3Price.ToString(), 3);
        createItemSlot(item4Image, item4Name, item4Price.ToString(), 4);
        createItemSlot(item5Image, item5Name, item5Price.ToString(), 5);

        // Set template-shopitem to invisible.
        shopItemTemplate.gameObject.SetActive(false);
    }

    // Create an item for in the store -> Image, Name, Cost, Position
    private void createItemSlot(Sprite itemSprite, string itemName, string itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTemplate.GetComponent<RectTransform>();

        //Set the shop-position on screen.
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        // Change the text-fields and image
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName.ToString());
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            //-------------------- Button-usability --------------------//
            /// <summary>
            /// This is where the buttons get value. They base the product off of the positionIndex of the shop.
            /// If you change the indexNumbers, make sure to change them here too.
            /// To add a new product, simply extend the code with another case (copy+paste an existing one) and change the names.
            /// </summary>

            switch (positionIndex) 
            {
                case 1:
                    if (moneyCount >= item1Price)
                    {
                        float pDay = lvlSystem.GetDayTime();
                        pDay -= timeDecrease;
                        lvlSystem.SetDayTime(pDay);
                        moneyCount -= item1Price;
                        Debug.Log("Set the clock back 3 hours!");
                        item1Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item1Price.ToString("F2"));
                    }
                    break;
                case 2:
                    if (moneyCount >= item2Price)
                    {
                        float pSpeed = plMovement.GetPlayerSpeed();
                        pSpeed += speedIncrease;
                        plMovement.SetPlayerSpeed(pSpeed);
                        moneyCount -= item2Price;
                        Debug.Log("Increased the movementspeed to " + pSpeed + "!");
                        item2Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item2Price.ToString("F2"));
                    }
                    break;
                case 3:
                    if (moneyCount >= item3Price)
                    {
                        int maxCarry = puSystem.GetMaxCarry();
                        maxCarry += carryIncrease;
                        puSystem.SetMaxCarry(maxCarry);
                        moneyCount -= item3Price;
                        Debug.Log("You can now hold " + maxCarry + " items!");
                        item3Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item3Price.ToString("F2"));
                    }
                    break;
                case 4:
                    if (moneyCount >= item4Price)
                    {
                        Debug.Log("This item still needs to be implemented!");
                    }
                    break;
                case 5:
                    if (moneyCount >= item5Price)
                    {
                        float pValue = puSystem.GetPlasticWorth();
                        pValue += valueIncrease;
                        puSystem.SetPlasticWorth(pValue);
                        moneyCount -= item5Price;
                        Debug.Log("Plastic has become more valuable! Each plastic is now worth " + pValue + "!");
                        item5Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item5Price.ToString("F2"));
                    }
                    break;
            }
        };
    }

    private void Update()
    {
        GetMoney();
        currentCarry = puSystem.GetCurrentCarry();
        // Update text with money-count
        money.GetComponent<TextMeshProUGUI>().SetText("Your influence: " + moneyCount.ToString("F2"));
        holdingText.GetComponent<TextMeshProUGUI>().SetText("Plastic holding: " + currentCarry);
    }


    // A simple getter-function to get PlayerMoney.
    public float GetMoney()
    {
        return moneyCount;
    }
    // A simple setter-function to set PlayerMoney.
    public void SetMoneyAmount(float pMoney)
    {
        moneyCount += pMoney;
    }
    // A simple reset-function for resetting PlayerMoney.
    public void ResetMoney()
    {
        moneyCount = 0f;
    }
}
