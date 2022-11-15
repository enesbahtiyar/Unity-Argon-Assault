using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private GameObject hitVfx;
    GameObject ParentGameObject;
    Scoreboard scoreboard;
    Rigidbody rb;

    [SerializeField] int hitpoints = 20;

    private void Awake()
    {
        
        AddRigidBody();
        scoreboard = GameObject.Find("ScoreBoard").GetComponent<Scoreboard>();
        ParentGameObject = GameObject.FindWithTag("VfxParent");
    }

    private void AddRigidBody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitpoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform;
        
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
  
        GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform;
        
        hitpoints--;
        scoreboard.increaseScore(10);
      
    }
}
