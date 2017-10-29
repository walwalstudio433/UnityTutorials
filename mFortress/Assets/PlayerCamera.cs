using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerCamera : MonoBehaviour
{

    public enum State { Free, Targeting };
    public State state;
    public Transform target;
    public float targetingSpeed;
    public float freeSpeed;

    void Update()
    {
        if (state == State.Targeting && target != null)
        {
            Vector2 v = Vector2.LerpUnclamped(transform.position, target.position, targetingSpeed * Time.deltaTime);
            transform.position = new Vector3(v.x, v.y, -100);
        }
    }

    public void ChaseTarget(Transform target)
    {
        state = State.Targeting;
        this.target = target;
    }

    public void MoveFeely(float vertical, float horizontal)
    {
        state = State.Free;
        transform.Translate(vertical * freeSpeed, horizontal * freeSpeed, 0);
    }

    public void LookAt(Vector3 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
