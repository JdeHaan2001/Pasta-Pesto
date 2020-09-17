using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class tooltipWindow : MonoBehaviour
{
    [SerializeField] private Transform container;
    private Tooltip tooltip;

    // -shopItemHeight * positionIndex

    // Start is called before the first frame update
    void Start()
    {
        transform.Find("windowOne").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.ShowTooltip_Static("Rewind the time 3 hours!");
        transform.Find("windowOne").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.HideTooltip_Static();
        transform.Find("windowTwo").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.ShowTooltip_Static("Increase your movement speed!");
        transform.Find("windowTwo").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.HideTooltip_Static();
        transform.Find("windowThree").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.ShowTooltip_Static("Allow yourself to carry more at once!");
        transform.Find("windowThree").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.HideTooltip_Static();
        transform.Find("windowFour").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.ShowTooltip_Static("Call for backup, allowing people to collect trash for you!");
        transform.Find("windowFour").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.HideTooltip_Static();
        transform.Find("windowFive").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.ShowTooltip_Static("Increase the amount of influence per plastic!");
        transform.Find("windowFive").GetComponent<Button_UI>().MouseOverOnceFunc = () => Tooltip.HideTooltip_Static();
    }
}
