using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public Text itemInfo;
    public Click click;
    public float cost;
    public float tickValue;
    public int count;
    public string itemName;

    public Color standardColor;
    public Color affordableColor;

    private float _baseCost;
    private Slider _slider;

	// Use this for initialization
	void Start ()
    {

        _baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
	}

    // Update is called once per frame
    void Update()
    {

        itemInfo.text = itemName + "\nCost: " + CurrencyConverter.Instance.GetCurrencyIntoString(cost,false,false) + "\nMetal: " + tickValue + "/sec";

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

    public void PurchasedItem()
    {
        if(click.metal >= cost)
        {
            click.metal -= cost;
            count += 1;
            cost = Mathf.Round(_baseCost * Mathf.Pow(1.15f, count));
        }
    }
}
