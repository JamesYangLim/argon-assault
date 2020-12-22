using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] [Tooltip("ms^-1")] float controlSpeed = 50f;
    [SerializeField] [Tooltip("m")] float xRange = 28f;
    [SerializeField] [Tooltip("m")] float yRange = 13f;

    [Header("Screen Position")]
    [SerializeField] float pitchFactor = -1.1f;
    [SerializeField] float yawFactor = 1.3f;

    [Header("Throw Control")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float rollFactor = -30f;

    float xThrow, yThrow;
    bool isControlEnable = true;

    void Update()
    {
        if (isControlEnable)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = rollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void FreezeController()
    {
        isControlEnable = false;
    }
}
