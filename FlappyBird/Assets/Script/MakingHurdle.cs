using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MakingHurdle : MonoBehaviour {
    public  GameObject hurdle ;
    public int velocity;
    public int minY;
    public int maxY;
    GameObject instance;
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("func", 1, 2);
       }

    // Update is called once per frame
    void Update()
    {
        //  instace.transform.Translate(Vector3.left);
        if (Input.GetButton("Cancel")) { 
        CancelInvoke();
     }
    }

    

    void func()
    {
        Vector3 position = transform.localPosition;
        position.y = Random.Range(minY, maxY);
        instance = Instantiate(hurdle, position,transform.rotation);
//        instance = Instantiate(hurdle, transform.localPosition, transform.rotation);
        instance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * velocity);
    }


}
