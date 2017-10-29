using System;
using System.Collections;
using UnityEngine;

public class Angler : MonoBehaviour
{
    public RectTransform minAngleUI, maxAngleUI, shotAngleUI;
    public float min, max, current;
    public float delta;    

    void Start()
    {        
        minAngleUI.localRotation = Quaternion.Euler(0, 0, min);
        maxAngleUI.localRotation = Quaternion.Euler(0, 0, max);
        shotAngleUI.localRotation = Quaternion.Euler(0, 0, current);
    }    

    public void Up()
    {
        current = current >= max ? max : current + delta;
        shotAngleUI.localRotation = Quaternion.Euler(0, 0, current);
    }

    public void Down()
    {
        current = current <= min ? min : current - delta;
        shotAngleUI.localRotation = Quaternion.Euler(0, 0, current);
    }
}
