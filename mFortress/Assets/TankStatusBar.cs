using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankStatusBar : MonoBehaviour
{
    public Slider hpBar;
    public Slider staminaBar;
    public Text nameText;

    void Start()
    {

    }
    
    void Update()
    {
        
    } 

    public void SetHPValue(float ratio)
    {
        hpBar.value = ratio;
    }

    public void SetStamaniaValue(float ratio)
    {
        staminaBar.value = ratio;
    }

    public void SetNameText(string text)
    {
        nameText.text = text;
    }
}
