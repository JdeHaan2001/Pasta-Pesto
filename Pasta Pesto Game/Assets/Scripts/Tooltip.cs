using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip instance;
    private Camera camera;
    private TextMeshProUGUI tooltipText;
    private RectTransform backgroundRectTransform;
    private RectTransform parentRectTransform;
    [SerializeField] private GameObject tooltipExample;
    private Transform container;

    private void Awake()
    {
        instance = this;
        container = tooltipExample.transform.Find("container");
        backgroundRectTransform = container.Find("background").GetComponent<RectTransform>();
        tooltipText = container.Find("text").GetComponent<TextMeshProUGUI>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

    }

    private void Start()
    {
        container.gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, camera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void showTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize*2f, tooltipText.preferredHeight + textPaddingSize*2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void hideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void doStartThing()
    {
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.showTooltip(tooltipString);
    }

    public static void HideTooltip_Static()
    {
        instance.hideTooltip();
    }
}
