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
    private Transform totalMoneyEarned;
    private Transform holdingText;
    private Transform panel;
    private Transform shopIcon;

    private PlayerMovement plMovement;
    private PickUpSystem puSystem;
    private LevelSystem lvlSystem;
    public GameObject player;
    public GameObject containerForVisibility;

    private bool levelIsStarting;
    private float shopItemHeight = 40f;
    private float valueIncrease = 0.5f;
    private float speedIncrease = 0.5f;
    private float timeDecrease = 0.125f;
    private float totalEarned = 0f;
    private float clockIncrease = 45f;
    private int carryIncrease = 2;
    private int currentCarry;


    //-------------------- Product Image --------------------//
    public Sprite item1Image;
    public Sprite item2Image;
    public Sprite item3Image;
    public Sprite item4Image;
    public Sprite item5Image;

    //-------------------- Product Name --------------------//
    private string item1Name = "Extra Time";
    private string item2Name = "Move Faster";
    private string item3Name = "Bigger Backpack";
    private string item4Name = "Advertisements";
    private string item5Name = "Plastic Value";

    //-------------------- Shop price --------------------//
    private float timePrice = 30f;
    private float speedPrice = 10f;
    private float carryPrice = 25f;
    private float advertPrice = 100f;
    private float valuePrice = 15f;

    void Awake()
    {
        levelIsStarting = true;


        // Assign the corresponding gameObject to the Transform variables.
        panel = transform.Find("Panel");
        shopIcon = panel.Find("shopIcon");
        money = shopIcon.Find("money");
        totalMoneyEarned = shopIcon.Find("totalEarned");
        container = panel.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        holdingText = panel.Find("holdingText");
        puSystem = player.GetComponent<PickUpSystem>();
        plMovement = player.GetComponent<PlayerMovement>();
        lvlSystem = player.GetComponent<LevelSystem>();

        // Start game with 0 "money"
        moneyCount = 0;


        // Add an item to the list of shopitems -> Image, Name, Cost, Position
        //-----------------------------------------------------------------------------------------
        // Simply add a new item by adding in a new line below, use the following template
        // TEMPLATE: createItemSlot(item[X]Image, item[X]Name, [item name]  .ToString(), [next number]);
        // Make sure to also add the image above at (//-------------------- Product Image --------------------//)
        // Make sure to also add the price above at (//-------------------- Shop price --------------------//)
        // Make sure to also add the index below at (//-------------------- Button-usability --------------------//)
        //-----------------------------------------------------------------------------------------
        createItemSlot(item1Image, item1Name, timePrice.ToString(), 1);
        createItemSlot(item2Image, item2Name, speedPrice.ToString(), 2);
        createItemSlot(item3Image, item3Name, carryPrice.ToString(), 3);
        createItemSlot(item4Image, item4Name, advertPrice.ToString(), 4);
        createItemSlot(item5Image, item5Name, valuePrice.ToString(), 5);

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
                    if (moneyCount >= timePrice)
                    {
                        float pDay = lvlSystem.GetDayTime();
                        pDay -= timeDecrease;
                        lvlSystem.SetDayTime(pDay);
                        moneyCount -= timePrice;
                        float pTime = lvlSystem.GetClockTime();
                        pTime += clockIncrease;
                        lvlSystem.SetClockTime(pTime);
                        Debug.Log("Set the clock back 3 hours!");
                        timePrice *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(timePrice.ToString("F2"));
                    }
                    break;
                case 2:
                    if (moneyCount >= speedPrice)
                    {
                        float pSpeed = plMovement.GetPlayerSpeed();
                        pSpeed += speedIncrease;
                        plMovement.SetPlayerSpeed(pSpeed);
                        moneyCount -= speedPrice;
                        Debug.Log("Increased the movementspeed to " + pSpeed + "!");
                        speedPrice *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(speedPrice.ToString("F2"));
                    }
                    break;
                case 3:
                    if (moneyCount >= carryPrice)
                    {
                        int maxCarry = puSystem.GetMaxCarry();
                        maxCarry += carryIncrease;
                        puSystem.SetMaxCarry(maxCarry);
                        moneyCount -= carryPrice;
                        Debug.Log("You can now hold " + maxCarry + " items!");
                        carryPrice *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(carryPrice.ToString("F2"));
                    }
                    break;
                case 4:
                    if (moneyCount >= advertPrice)
                    {
                        Debug.Log("This item still needs to be implemented!");
                    }
                    break;
                case 5:
                    if (moneyCount >= valuePrice)
                    {
                        float pValue = puSystem.GetPlasticWorth();
                        pValue += valueIncrease;
                        puSystem.SetPlasticWorth(pValue);
                        moneyCount -= valuePrice;
                        Debug.Log("Plastic has become more valuable! Each plastic is now worth " + pValue + "!");
                        valuePrice *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(valuePrice.ToString("F2"));
                    }
                    break;
            }
        };
    }

    private void Update()
    {
        if (levelIsStarting)
        {
            containerForVisibility.SetActive(false);
            levelIsStarting = false;
        }
        GetMoney();
        currentCarry = puSystem.GetCurrentCarry();
        // Update text with money-count
        money.GetComponent<TextMeshProUGUI>().SetText("Your influence: " + moneyCount.ToString("F2"));
        totalMoneyEarned.GetComponent<TextMeshProUGUI>().SetText("Total earned " + moneyCount.ToString("F2"));
        holdingText.GetComponent<TextMeshProUGUI>().SetText("Plastic holding: " + currentCarry);
    }


    public void SetTotalEarned(float pMoney) 
    {
        totalEarned += pMoney;
    }

    public float GetTotalEarned()
    {
        return totalEarned;
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
