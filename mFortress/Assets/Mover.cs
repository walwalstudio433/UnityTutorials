using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform target;
    public Transform rotatable;
    public enum Direciton { Left, Right };
    public Direciton direction;

    public float maxStamina;
    public float stamina;
    public float speed;
    public float deltaStamina;
    public float StaminaRatio { get { return stamina / maxStamina; } }
    public Vector3 forward, normal;

    private Transform trans;
    
    void Start()
    {
        trans = transform;
    }

    void Update()
    {
        normal = trans.rotation * Vector3.up;
        forward = trans.rotation * Vector3.right;
    }

    public void MoveLeft()
    {
        if (direction == Direciton.Right)
            ChangeDirection(Direciton.Left);        
        MoveForward();
    }

    public void MoveRight()
    {
        if (direction == Direciton.Left)
            ChangeDirection(Direciton.Right);
        MoveForward();
    }

    private void ChangeDirection(Direciton to)
    {
        rotatable.Rotate(normal, 180f, Space.World);
        direction = to;
    }

    private void MoveForward()
    {
        if (stamina <= 0)
            return;
        stamina = stamina > 0 ? stamina - deltaStamina : 0;
        target.localPosition += forward * speed;
    }

    public void Reset()
    {
        stamina = maxStamina;
    } 
}
