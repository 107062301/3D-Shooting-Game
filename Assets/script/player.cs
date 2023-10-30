using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Slider adjust;
    public Transform target;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Transform>().position = new Vector3(target.position.x-3,2.1f, target.position.z);
        gameObject.GetComponent<Transform>().position = new Vector3(target.position.x , 1, target.position.z) + transform.right*adjust.value;
    }
    private void FixedUpdate()
    {
        //keycheck();
    }

    void keycheck()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(3, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(-3, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(0, 0, 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(0, 0, -3);
        }
    }
}
