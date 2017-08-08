using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SHIFT + ALT + (UP or DOWN Arrows)

public class Player : MonoBehaviour
{
    // <access-specifier>
    public int lives = 3;
    public float rotationSpeed = 2;
    public float movementSpeed = 5;
    public float acceleration = 50f;
    public float deceleration = .1f;

    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Before Setting Rigid:" + rigid);
        rigid = GetComponent<Rigidbody2D>();
        Debug.Log("After Setting Rigid:" + rigid);

    }

    // Update is called once per frame
    void Update()
    {
        // If user presses W
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move forward
            rigid.AddForce(transform.right * acceleration);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(-transform.right * acceleration);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.back);
        }
        // Deceleration
        rigid.velocity += -rigid.velocity * deceleration;
    }
}
