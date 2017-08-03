using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingTopHurdle : MonoBehaviour
{
    public GameObject hurdle;
    public int velocity;
    public int minY;
    public int maxY;
    public static float RepeatRate = 2.0F;
    public static bool changeFlag;
    GameObject instance;

    void Start()
    {
        changeFlag = true;
    }

    void Update()
    {

        if (changeFlag)
        {
            CancelInvoke();
            InvokeRepeating("func", 1, RepeatRate);
            changeFlag = false;
        }
    }

    void func()
    {
        Vector3 position = transform.localPosition;
        position.y = Random.Range(minY, maxY);
        instance = Instantiate(hurdle, position, transform.rotation);
        //        instance = Instantiate(hurdle, transform.localPosition, transform.rotation);
        instance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * velocity);
    }

    public static void faster()
    {
        if (RepeatRate > 0.3F)
        {
            RepeatRate = RepeatRate - 0.2F;
        }
        changeFlag = true;
    }


}
