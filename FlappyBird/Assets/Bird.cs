using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKey)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
	}

    public void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            //0~-90도 사이를 3번째 값만큼 
            transform.rotation = Quaternion.Euler(0, 0, angle);
            //쿼터니언으로 바꿔서 set을 해줘야...
        }
    }

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
