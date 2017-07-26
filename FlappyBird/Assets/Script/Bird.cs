﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("#: " + transform.rotation.z);
        if (Input.GetButton("Fire1"))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
            if (transform.rotation.z < 0.08) {
                transform.Rotate(new Vector3(0, 0, 1.5f));
            }
        }
        else if (transform.rotation.z > -0.03)
        {
            transform.Rotate(new Vector3(0, 0, -0.4f));
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);   //캐릭터의 카메라에서 보고있는 월드포지션 위치값을 받아와서
       if (screenPosition.y > Screen.height || screenPosition.y < 0)   //y축 값이 카메라 기준 0보다 작거나 카메라 범위의 높이보다 크면 죽는거에요.
        {
            Die();
        }

    }
    void Die()
    {
        Application.LoadLevel("Ready"); //얘는 앱 다시 로드하는거구요. 간단하죠
    }

    void OnTriggerEnter2D(Collider2D pipe) //Collision2D 객체는 상대방 Collider 객체에요. 이게 충돌나면 이함수 호출하려고 만드는거에요
    { 
        Die();
    }
}
