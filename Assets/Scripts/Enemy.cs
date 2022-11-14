using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private Transform parent;
    Scoreboard scoreboard;

    private void Awake()
    {
        scoreboard = GameObject.Find("ScoreBoard").GetComponent<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreboard.increaseScore(10);
    }
}
