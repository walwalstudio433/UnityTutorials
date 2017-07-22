using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingHurdle : MonoBehaviour {
    public  GameObject hurdle ;
    public int velocity;
    public int minY;
    public int maxY;
    GameObject instance;
    
    void Start () {
        InvokeRepeating("func", 1, 2);
       }
    
    void Update()
    {
        if (Input.GetButton("Cancel")) {    CancelInvoke();   }
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
