using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMoving : MonoBehaviour
{

    public float scrollSpeed;
    public GameObject startBackGround;
    public GameObject endBackGround;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 thisPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = startBackGround.transform.position;  //이게 바닥이 처음 만들어질 위치
        endPosition = endBackGround.transform.position;     //바닥이 사라질 위치를 각각 해당위치에서 생성되는 바닥에서 받아와요
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < endPosition.x - 1)    //그러다가 사라직 위치로 오면
        {
            transform.position = startPosition;                //시작 위치로 이동
        }
        transform.position = transform.position + (Vector3.right * scrollSpeed); //그게 아니라면 계속 이동하도록
    }
}