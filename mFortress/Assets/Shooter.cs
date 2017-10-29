using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : ShootRecharger
{   
    public float barrelLength;
    public float dmgCoeff;
   
    public GameObject bullet;

    public float maxPower;
    public float power;
    public float deltaPower;
    public float PowerRatio { get { return power / maxPower; } }

    public Slider powerBar;

    void Start()
    {
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
    }    

    public void PowerUp()
    {
        power = power < maxPower ? power + deltaPower : maxPower;
        if(powerBar != null){
            powerBar.value = PowerRatio;
        }
    }
    
    public void Reset()
    {
        power = 0;
        if(powerBar != null){
            powerBar.value = 0;
        }
    } 

    public Bullet Launch(Vector3 to)
    {
        Bullet bullet = Instantiate(this.bullet).GetComponent<Bullet>();
        bullet.transform.position = transform.position + to.normalized * barrelLength;
        bullet.GetComponent<Rigidbody>().AddForce(to, ForceMode.Impulse);
        return bullet;        
    }
}
