using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earth_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float life = 3.0f,life2 = 7;
    bool up = true;
    string cc = "b";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name[6].ToString() == cc)
        {
            life -= Time.deltaTime;
            if (life <= 0) Destroy(gameObject);
            else if (life < 1 && life > 0) gameObject.GetComponent<Transform>().position -= new Vector3(0, 0.1f, 0);
            // Debug.Log(life);
            //transform.position += transform.forward * 20 * Time.deltaTime;
            if (gameObject.GetComponent<Transform>().position.y <= 0.3f && up)
            {
                gameObject.GetComponent<Transform>().position += new Vector3(0, 0.1f, 0);
            }
            else
            {
                up = false;
            }
        }
        else
        {
            life2 -= Time.deltaTime;
            if (life2 <= 0) Destroy(gameObject);
            else if (life2 < 1 && life2 > 0) gameObject.GetComponent<Transform>().position -= new Vector3(0, 0.3f, 0);
            // Debug.Log(life);
            //transform.position += transform.forward * 20 * Time.deltaTime;
            if (gameObject.GetComponent<Transform>().position.y <= 0.75f && up)
            {
                gameObject.GetComponent<Transform>().position += new Vector3(0, 0.3f, 0);
            }
            else
            {
                up = false;
            }
        }
        //gameObject.GetComponent<Transform>().position += new Vector3(0, 0.01f, 0);
    }
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "wall" || collision.gameObject.tag == "bush") Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
