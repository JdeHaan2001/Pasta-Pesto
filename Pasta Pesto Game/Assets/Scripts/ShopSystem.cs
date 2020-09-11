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

    //-------------------- Product count --------------------//
    private int item1Count = 0;
    private int item2Count = 0;
    private int item3Count = 0;
    private int item4Count = 0;
    private int item5Count = 0;

    void Awake()
    {
        // Assign the corresponding gameObject to the Transform variables.
        money = transform.Find("money");
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");

        // Start game with 0 "money"
        moneyCount = 0;
    }

    private void Start()
    {
        // Add an item to the list of shopitems -> Image, Name, Cost, Position
        //-----------------------------------------------------------------------------------------
        // Simply add a new item by adding in a new line below, use the following template
        // TEMPLATE: createItemSlot(item[X]Image, item[X]Name, item[X]Prie.ToString(), [next number]);
        // Make sure to also add the image above at (//-------------------- Product Image --------------------//)
        // Make sure to also add the price above at (//-------------------- Shop price --------------------//)
        // Make sure to also add the count above at (//-------------------- Product Count --------------------//)
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
        float shopItemHeight = 50f;
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
            /// Try using logical names so everyone can understand them.
            /// </summary>

            switch (positionIndex) 
            {
                case 1:
                    if (moneyCount >= item1Price)
                    {
                        item1Count += 1;
                        moneyCount -= item1Price;
                        Debug.Log("ADDED 1 PLASTIBOT MK1! TOTAL IS NOW: " + item1Count);
                        item1Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item1Price.ToString("F2"));
                    }
                    break;
                case 2:
                    if (moneyCount >= item2Price)
                    {
                        item2Count += 1;
                        moneyCount -= item2Price;
                        Debug.Log("ADDED 1 PLASTIBOT MK2! TOTAL IS NOW: " + item2Count);
                        item2Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item2Price.ToString("F2"));
                    }
                    break;
                case 3:
                    if (moneyCount >= item3Price)
                    {
                        item3Count += 1;
                        moneyCount -= item3Price;
                        Debug.Log("ADDED 1 PLASTIBOT MK3! TOTAL IS NOW: " + item3Count);
                        item3Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item3Price.ToString("F2"));
                    }
                    break;
                case 4:
                    if (moneyCount >= item4Price)
                    {
                        item4Count += 1;
                        moneyCount -= item4Price;
                        Debug.Log("ADDED 1 FACEBOOK AD! TOTAL IS NOW: " + item4Count);
                        item4Price *= multiplier;
                        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(item4Price.ToString("F2"));
                    }
                    break;
                case 5:
                    if (moneyCount >= item5Price)
                    {
                        item5Count += 1;
                        moneyCount -= item5Price;
                        Debug.Log("ADDED 1 NICKELODEON AD! TOTAL IS NOW: " + item5Count);
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
        // Update text with money-count
        money.GetComponent<TextMeshProUGUI>().SetText("Your influence: " + moneyCount.ToString("F2"));
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

    public void ResetMoney()
    {
        moneyCount = 0f;
    }
}
