using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

    public Text metalDisplay;
    public Text metalPerClickText;
    public float metal = 0;
    public float metalPerClick = 1;

    void Update()
    {
        //Update text displaying our money, ToString hides decimal places
        metalDisplay.text = "Metal: " + CurrencyConverter.Instance.GetCurrencyIntoString(metal, false, false);
        metalPerClickText.text = CurrencyConverter.Instance.GetCurrencyIntoString(metalPerClick, false, true); // + " metal/click";
        
    }

    public void Clicked()
    {
        //Increment on click
        metal += metalPerClick;
    }
}
