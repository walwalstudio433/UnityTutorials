using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class InputManager : MonoBehaviour {

    public static InputManager Instance { get; set; }
    public KeyCode current;
    public enum State{Idle, Down, Holding, Up};
    public State state;
    public List<KeyCode> enables;    

    public void SendKeyDown(KeyCode key)
    {
        Instance.state = State.Down;
        Instance.current = key;        
    }

    public void SendKeyHolding(KeyCode key)
    {
        Instance.state = State.Holding;
        Instance.current = key;
    }

    public void SendKeyUp(KeyCode key)
    {
        Instance.state = State.Up;
        Instance.current = key;
    }

    public void SendKeyDown(string key)
    {
        Instance.state = State.Down;
        Instance.current = (KeyCode)Enum.Parse(typeof(KeyCode), key);
    }

    public void SendKeyHolding(string key)
    {
        Instance.state = State.Holding;
        Instance.current = (KeyCode)Enum.Parse(typeof(KeyCode), key);
    }

    public void SendKeyUp(string key)
    {
        Instance.state = State.Up;
        Instance.current = (KeyCode)Enum.Parse(typeof(KeyCode), key);
    }

    public void SendKeyDown(int key)
    {
        Instance.state = State.Down;
        Instance.current = (KeyCode)key;
    }

    public void SendKeyHolding(int key)
    {
        Instance.state = State.Holding;
        Instance.current = (KeyCode)key;
    }

    public void SendKeyUp(int key)
    {
        Instance.state = State.Up;
        Instance.current = (KeyCode)key;
    }

    public static bool AnyArrowKeyDown()
    {
        return Instance.state == State.Down && AnyArrowKey();
    }

    public static bool AnyArrowKeyHolding()
    {
        return Instance.state == State.Holding && AnyArrowKey();
    }

    public static bool AnyArrowKeyUp()
    {
        return Instance.state == State.Up && AnyArrowKey();
    }

    public static bool AnyArrowKey()
    {
        return GetKey(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);
    }

    public static bool GetKeyDown(KeyCode key)
    {
        return Instance.state == State.Down && Instance.current == key;
    }

    public static bool GetKeyDown(params KeyCode[] key)
    {
        
        return Instance.state == State.Down && GetKey(key);
    }

    public static bool GetKeyHolding(params KeyCode[] key)
    {
        return Instance.state == State.Holding && GetKey(key);
    }

    public static bool GetKeyUp(params KeyCode[] key)
    {
        return Instance.state == State.Up && GetKey(key);
    }
    public static bool GetKey(params KeyCode[] key){
        for (int i = 0; i < key.Length; i++)
        {
            if(key[i] == Instance.current)
                return true;
        }
        return false;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start () 
    {

    }
	
	void Update ()
    {
        for (int i = 0; i < enables.Count; i++)
        {
            KeyCode enable = enables[i];
            if (Input.GetKeyDown(enable))
            {
                SendKeyDown(enable);
            }
            else if (Input.GetKey(enable))
            {
                SendKeyHolding(enable);
            }
            else if (Input.GetKeyUp(enable))
            {
                SendKeyUp(enable);
            }
        }
    }
    
    void LateUpdate()
    {
        if(state == State.Up)
        {
            state = State.Idle;
            current = default(KeyCode);
        }
    }    
}