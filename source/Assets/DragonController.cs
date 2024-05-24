using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;

    private void OnEnable()
    {
        // Locate the FixedJoystick component in the scene
        fixedJoystick = FindObjectOfType<FixedJoystick>();

        // Get the Rigidbody component attached to this GameObject
        rigidBody = GetComponent<Rigidbody>();

        if (fixedJoystick == null)
        {
            Debug.LogError("FixedJoystick not found in the scene.");
        }

        if (rigidBody == null)
        {
            Debug.LogError("Rigidbody component missing from this GameObject.");
        }
    }

    private void FixedUpdate()
    {
        if (fixedJoystick == null || rigidBody == null) return;

        // Read the joystick input
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        // Calculate movement vector
        Vector3 movement = new Vector3(xVal, 0, yVal) * speed;

        // Apply movement to the Rigidbody
        rigidBody.velocity = movement;

        // If there is movement input, rotate the dragon accordingly
        if (xVal != 0 || yVal != 0)
        {
            float angle = Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
