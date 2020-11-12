using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] [Tooltip("ms^-1")] float speed = 35f;
    [SerializeField] [Tooltip("m")] float xClamp = 20f;
    [SerializeField] [Tooltip("m")] float yClamp = 10f;

    [SerializeField] float pitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -25f;

    [SerializeField] float yawFactor = 1f;
    [SerializeField] float rollFactor = -30f;

    float xThrow, yThrow;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xClamp, xClamp);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yClamp, yClamp);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = rollFactor * xThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
