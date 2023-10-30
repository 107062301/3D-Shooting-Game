using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensity = 200f;
    public Transform player,player2;
    public Quaternion Rotatex, Rotatey;
    bool E_press = false;
    float rotx = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!E_press)
        {
            float mx = Input.GetAxis("Mouse X") * sensity * Time.deltaTime;
            float my = Input.GetAxis("Mouse Y") * sensity * Time.deltaTime;
            /*float dx = player.position.x, dy = player.position.y, dz = player.position.z;
            gameObject.GetComponent<Transform>().position = new Vector3(dx,dy+3,dz+10);*/
            //gameObject.GetComponent<Transform>().rotation = player.rotation;

            rotx -= my;
            rotx = Mathf.Clamp(rotx, -90f, 90f);
            transform.localRotation = Quaternion.Euler(rotx, 0f, 0f);
            player.Rotate(Vector3.up * mx);
            //player2.Rotate(Vector3.up * mx);
            //Debug.Log(player.rotation);
            Rotatey = player.rotation;
            Rotatex = Quaternion.Euler(rotx, 0f, 0f);
            //Debug.Log(Rotatey);
            //Debug.Log(Quaternion.Euler(rotx, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            E_press = !E_press;
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
