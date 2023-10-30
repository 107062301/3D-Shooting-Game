using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float life = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if (life <= 0) Destroy(gameObject);
        transform.position += transform.forward * 25 * Time.deltaTime;
        
    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -6, 0), ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "wall" || collision.gameObject.name == "Plane") Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "wall" || other.gameObject.name == "Plane") Destroy(gameObject);
        if (other.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
