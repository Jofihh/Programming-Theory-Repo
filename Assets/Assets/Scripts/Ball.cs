using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float baseSpeed = 2.5f;
    private bool isLaunched = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.linearVelocity = new Vector3(1, 1, 0).normalized * baseSpeed;
            isLaunched = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (!isLaunched) return;

        Vector3 velocity = m_Rigidbody.linearVelocity;

        // Ensure the ball does not move too vertically or horizontally
        if (Mathf.Abs(velocity.y) < 0.3f)
        {
            velocity.y = velocity.y > 0 ? 0.3f : -0.3f;
        }

        if (Mathf.Abs(velocity.x) < 0.3f)
        {
            velocity.x = velocity.x > 0 ? 0.3f : -0.3f;
        }

        m_Rigidbody.linearVelocity = velocity.normalized * baseSpeed;
    }
}