using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    public int limitY;
    public int basicDmg;
    public Transform trans;
    public GameObject explosionPrefab;

    void Start()
    {
        
    }     

    void Update()
    {
        if(trans.position.y < limitY)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!isServer)
            return;

        other.gameObject.SendMessage("RpcTakeDamage", basicDmg, SendMessageOptions.DontRequireReceiver);
        RpcBulletExplode();        
    }

    [ClientRpc]
    void RpcBulletExplode()
    {
        ParticleSystem explosion = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosion.transform.position = transform.position;
        Destroy(explosion.gameObject, explosion.main.duration);
        Destroy(gameObject);
    }
}
