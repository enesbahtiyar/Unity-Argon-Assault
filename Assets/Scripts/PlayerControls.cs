using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based upon player input")][SerializeField] private float controlspeed = 10f;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yRange = 9f;

    [Header("Laser Gun array")]
    [Tooltip("add all player guns in here")]
    [SerializeField] GameObject[] Lasers;

    [Header(("Screen position based tuning"))]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = 10f;


    float yThrow;
    float xThrow;
    void Update()
    {
        ProcessTranslaton();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach(GameObject lasers in Lasers)
        {
            if (isActive == true)
            {
                var emissionModule = lasers.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = true;
            }
            else if (isActive == false)
            {
                var emissionModule = lasers.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = false;
            }
            
        }
    }    

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(-pitch ,yaw, roll);
    }

    private void ProcessTranslaton()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlspeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        


        float yOffset = yThrow * Time.deltaTime * controlspeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }
}
