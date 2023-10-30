using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chan_ele : MonoBehaviour
{
    // Start is called before the first frame update
    public Material f1, f2, f3, f4;
    public Material e1, e2, e3, e4;
    public Material s1, s2, s3, s4;
    public Dropdown DP;
    public SkinnedMeshRenderer lod1, lod2, lod3, lod4;
    public Rigidbody fire_bullet, steel_bullet, earth_bullet, earth_shield;
    public GameObject cam,aim1,aim2,aim3;
    public Transform health;
    public Text left, success;
    float clock = 0.1f, earth_rate = 1.5f, cool = 0.5f;
    bool do_once = true;
    Vector3 ori_pos, ori_rot, ori_cam_f, ori_cam_r;
    int count = 1, clock2 = 0, bullet_left = 3;
    void Start()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
    public void chan_element()
    {
        if (do_once)
        {
            DP.options.RemoveAt(3);
            do_once = false;
        }
        Material[] mats1 = lod1.materials, mats2 = lod2.materials, mats3 = lod3.materials, mats4 = lod4.materials;
        if (DP.value == 0)
        {
            mats1[0] = mats2[0] = mats3[0]= mats3[0]= f1;
            mats1[2] = mats2[2] = mats3[2] = mats3[2] = f2;
            mats1[3] = mats2[3] = mats3[3] = mats3[3] = f3;
            mats1[4] = mats2[4] = mats3[4] = mats3[4] = f4;
            aim1.SetActive(true);
            aim2.SetActive(false);
            aim3.SetActive(false);
        }
        else if (DP.value == 1)
        {
            mats1[0] = mats2[0] = mats3[0] = mats3[0] = e1;
            mats1[2] = mats2[2] = mats3[2] = mats3[2] = e2;
            mats1[3] = mats2[3] = mats3[3] = mats3[3] = e3;
            mats1[4] = mats2[4] = mats3[4] = mats3[4] = e4;
            aim3.SetActive(true);
            aim2.SetActive(false);
            aim1.SetActive(false);
        }
        else if (DP.value == 2)
        {
            mats1[0] = mats2[0] = mats3[0] = mats3[0] = s1;
            mats1[2] = mats2[2] = mats3[2] = mats3[2] = s2;
            mats1[3] = mats2[3] = mats3[3] = mats3[3] = s3;
            mats1[4] = mats2[4] = mats3[4] = mats3[4] = s4;
            aim2.SetActive(true);
            aim1.SetActive(false);
            aim3.SetActive(false);
        }
        lod1.materials = mats1;
        lod2.materials = mats2;
        lod3.materials = mats3;
        lod4.materials = mats4;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q)) shoot_fire();
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(1)) && bullet_left > 0)
        {
            if(DP.value == 2) shoot_steel();
            if (DP.value == 0) shoot_fire();
            if (DP.value == 1) shoot_earth();
            bullet_left -= 1;
        }
        if(bullet_left < 3)
        {
            cool -= Time.deltaTime;
            if(cool <= 0)
            {
                cool = 1.3f;
                bullet_left += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("main");
        }

        if (health.GetComponent<RectTransform>().sizeDelta.x <= 0)
        {
            if(SceneManager.GetActiveScene().name == "game") SceneManager.LoadScene("game");
            else SceneManager.LoadScene("game2");
        }

        if (SceneManager.GetActiveScene().name == "game" && success.text == "1000")
        {
            SceneManager.LoadScene("success");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (SceneManager.GetActiveScene().name == "game2" &&  success.text == "1400")
        {
            SceneManager.LoadScene("success");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        left.text = bullet_left.ToString();
    }

    void shoot_earth()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        Vector3 prefab = new Vector3(pos.x, pos.y + 1, pos.z);
        Quaternion qx = cam.GetComponent<cam>().Rotatey;
        float an = qx.eulerAngles.y;
        Rigidbody fb, fb2;
        ori_pos = gameObject.transform.position + new Vector3(0, -0.45f, 0);
        ori_cam_f = cam.transform.forward;
        ori_cam_r = cam.transform.right;
        ori_rot = cam.transform.forward;
        fb = Instantiate(earth_shield, prefab, Quaternion.identity);
        fb.transform.position = gameObject.transform.position + new Vector3(0, -0.75f, 0) + transform.right * 1.2f + transform.forward * 1f; 
        fb.transform.forward = transform.forward - transform.right * 1.5f;
        fb2 = Instantiate(earth_shield, prefab, Quaternion.identity);
        fb2.transform.position = gameObject.transform.position + new Vector3(0, -0.75f, 0) - transform.right * 1.2f + transform.forward * 1f;
        fb2.transform.forward = transform.forward + transform.right * 1.5f;
        InvokeRepeating("earth_blt", 0.4f, 0.4f);
    }
    void earth_blt()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        Vector3 prefab = new Vector3(pos.x, pos.y + 1, pos.z);
        Quaternion qx = cam.GetComponent<cam>().Rotatey;
        float an = qx.eulerAngles.y;
        Rigidbody fb, fb2, fb3;
        fb = Instantiate(earth_bullet, prefab, Quaternion.identity);
        fb.transform.position = ori_pos + ori_cam_f * earth_rate + ori_cam_r * 1.2f;
        fb.transform.forward = ori_rot;
        fb2 = Instantiate(earth_bullet, prefab, Quaternion.identity);
        fb2.transform.position = ori_pos + ori_cam_f * earth_rate - ori_cam_r * 1.2f;
        fb2.transform.forward = ori_rot;
        fb3 = Instantiate(earth_bullet, prefab, Quaternion.identity);
        fb3.transform.position = ori_pos + ori_cam_f * earth_rate * 1.11f + new Vector3(0,0.1f,0);
        fb3.transform.forward = ori_rot;

        earth_rate += 0.8f;
        clock2 += 1;
        if (clock2 >= 25)
        {
            clock2 = 0;
            earth_rate = 1.5f;
            CancelInvoke();
        }
    }
    void shoot_fire()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        Vector3 prefab = new Vector3(pos.x, pos.y+1, pos.z);
        Quaternion qx = cam.GetComponent<cam>().Rotatey;
        float an = qx.eulerAngles.y;
       /* Debug.Log(an);
        Debug.Log(dir);*/
        Rigidbody fb;
        fb = Instantiate(fire_bullet, prefab, Quaternion.identity);
        fb.transform.position = gameObject.transform.position + new Vector3(0,1,0) + cam.transform.forward * 1.2f;
        fb.transform.forward = cam.transform.forward + cam.transform.up*0.1f; 
        //Debug.Log(fb.transform.forward);
       
    }
    void shoot_steel()
    {
        
        InvokeRepeating("steel_blt", 0.2f, 0.2f);
        
    }
    void steel_blt()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        Vector3 prefab = new Vector3(pos.x, pos.y + 1, pos.z);
        Vector3 p1 = new Vector3(pos.x, pos.y + 1.2f, pos.z) + gameObject.transform.right * 1.5f - gameObject.transform.up * 1;
        Vector3 p2 = new Vector3(pos.x, pos.y + 1.2f, pos.z) + gameObject.transform.right * 0.6f - gameObject.transform.up * 0.5f;
        Vector3 p3 = new Vector3(pos.x, pos.y + 1.2f, pos.z) + gameObject.transform.right * -0.9f - gameObject.transform.up * 1.2f;
        Vector3 p4 = new Vector3(pos.x, pos.y + 1.2f, pos.z) + gameObject.transform.right * -1.3f - gameObject.transform.up * 0.8f;
        Quaternion qx = cam.GetComponent<cam>().Rotatey;
        float an = qx.eulerAngles.y;
        /* Debug.Log(an);
         Debug.Log(dir);*/
        Rigidbody fb1;
        if (count == 1)
        {
            fb1 = Instantiate(steel_bullet, p1, Quaternion.identity);
            fb1.transform.position = p1 + new Vector3(0, 1, 0) + cam.transform.forward * 1.5f;
            fb1.transform.forward = cam.transform.forward;
            count++;
        }
        else if(count == 2)
        {
            fb1 = Instantiate(steel_bullet, p1, Quaternion.identity);
            fb1.transform.position = p2 + new Vector3(0, 1, 0) + cam.transform.forward * 1.5f;
            fb1.transform.forward = cam.transform.forward;
            count++;
        }
        else if (count == 3)
        {
            fb1 = Instantiate(steel_bullet, p1, Quaternion.identity);
            fb1.transform.position = p3 + new Vector3(0, 1, 0) + cam.transform.forward * 1.5f;
            fb1.transform.forward = cam.transform.forward;
            count++;
        }
        else if (count == 4)
        {
            fb1 = Instantiate(steel_bullet, p1, Quaternion.identity);
            fb1.transform.position = p4 + new Vector3(0, 1, 0) + cam.transform.forward * 1.5f;
            fb1.transform.forward = cam.transform.forward;
            count = 1;
            CancelInvoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ene_bullet")
        {
            
            gameObject.GetComponent<chan_ele>().health.GetComponent<RectTransform>().sizeDelta -= new Vector2(8f, 0);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }
}
