using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
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
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        playerControls.enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
