using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TrainingUI : MonoBehaviour
{
    public Slider timeSlider;
    public Text timeText;
    public Text payoffText;
    public Text costTest;
    string payoffString = string.Empty;
    bool selectHealth, selectDex, selectInt, selectStr = false;
    int sliderValue = 0;

    void Start()
    {
        SliderUpdate();
    }

    public void SliderUpdate()
    {
        sliderValue = (int)timeSlider.value;
        UpdateValues();
    }

    public void SelectStat(string statName)
    {
        switch(statName)
        {
            case "HEALTH":
                selectHealth = !selectHealth;
                break;
            case "DEXTARITY":
                selectDex = !selectDex;
                break;
            case "INTELLECT":
                selectInt = !selectInt;
                break;
            case "STRENGTH":
                selectStr = !selectStr;
                break;
        }
        UpdateValues();
    }

    void UpdateValues()
    {
        timeText.text = sliderValue.ToString() + " Hours";
        payoffString = "Increase ";
        int multiplier = 1;
        if (selectHealth)
        {
            payoffString += " <i>HEALTH POINTS</i>,";
            multiplier++;
        }
        if (selectDex)
        {
            payoffString += " <i>DEXTARITY</i>,";
            multiplier++;
        }
        if (selectInt)
        {
            payoffString += " <i>INTELLECT</i>,";
            multiplier++;
        }
        if (selectStr)
        {
            payoffString += " <i>STRENGTH</i>,";
            multiplier++;
        }

        payoffString = payoffString.TrimEnd(',', ' ', '\n');
        payoffString += " by <color=#f44141>+" + (sliderValue * 100).ToString() + " EXP</color>";
        if (multiplier == 1)
        {
            payoffString = " ";
            costTest.text = "Cost: " + 0.ToString();
        }
        else
        {
            costTest.text = "Cost: " + (sliderValue * 20 * multiplier).ToString();
        }

        payoffText.text = payoffString;


    }

    

}
