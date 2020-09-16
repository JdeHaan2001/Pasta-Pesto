using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    private bool shopVisible = false;
    public GameObject Container;

    public void ChangeVisibility()
    {
        if(shopVisible == false)
        {
            shopVisible = true;
            Container.SetActive(false);
        }
        else if(shopVisible == true)
        {
            shopVisible = false;
            Container.SetActive(true);
        }
    }


}
