using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Click click;
    public Text itemInfo;
    public float cost;
    public int count = 0;
    public int clickPower;
    public string itemName;

    private Slider _slider;
    private float _baseCost;
    public Color standardColor;
    public Color affordableColor;


    void Start()
    {
        _baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        // \n = new line
        itemInfo.text = itemName + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nPower: +" + clickPower;

        _slider.value = click.metal / cost * 100;

        if (_slider.value >= 100)
               {
                   GetComponent<Image>().color = affordableColor;
               }
               else
               {
                   GetComponent<Image>().color = standardColor;
               }
               

    }

    public void PurchasedUpgrade()
    {
        if (click.metal >= cost)
        {
            click.metal -= cost;
            count += 1;
            click.metalPerClick += clickPower;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.15f, count));
        }
    }
}
