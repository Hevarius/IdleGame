using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalPerSecond : MonoBehaviour {

    public Text metalPerSecondDisplay;
    public Click click;
    public ItemManager[] items;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AutoTick());
    }


    // Update is called once per frame
    void Update()
    {
        metalPerSecondDisplay.text = CurrencyConverter.Instance.GetCurrencyIntoString(GetMetalPerSecond(), true, false); // + " metal/sec";
    }

    public float GetMetalPerSecond()
    {
        float tick = 0;

        foreach(ItemManager item in items)
        {
            tick += item.count * item.tickValue;
        }

        return tick;
    }

    public void AutoMetalPerSecond()
    {
        click.metal += GetMetalPerSecond()/ 10;
    }

    IEnumerator AutoTick()
    {
        while(true)
        {
            //increment metal
            AutoMetalPerSecond();
            //return every second
            yield return new WaitForSeconds(0.1f);
        }
    }
	
}
