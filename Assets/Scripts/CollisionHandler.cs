using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + " collided with " + other.gameObject.name);
        StartCrashSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} **Triggered By** {other.gameObject.name}");
    }

    private void StartCrashSequence()
    {
        crashVFX.Play();
        playerControls.enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
