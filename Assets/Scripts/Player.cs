using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField][Tooltip("ms^-1")] float speed = 20f;
    
    [SerializeField] float xClamp = 10f;
    [SerializeField] float yClamp = 10f;

    [SerializeField] float yawClamp = 10f;
    [SerializeField] float pitchClamp = 5f;
    [SerializeField] float rollClamp = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        ProcessTranslation(xThrow, yThrow);
        ProcessRotation(xThrow);
    }

    void ProcessTranslation(float xThrow, float yThrow)
    {
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xClamp, xClamp);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yClamp, yClamp);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    void ProcessRotation(float xThrow)
    {
        float yaw = (transform.localPosition.x / xClamp) * yawClamp;
        float pitch = (transform.localPosition.y / yClamp) * -pitchClamp;
        float roll = -rollClamp * xThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
