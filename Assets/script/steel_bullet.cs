using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steel_bullet : MonoBehaviour
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
        transform.position += transform.forward * 35 * Time.deltaTime;

    }
    private void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "wall" || other.gameObject.name == "Plane" || other.gameObject.tag == "bush") Destroy(gameObject);
        if (other.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
    }
}
