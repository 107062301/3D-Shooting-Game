using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ma : MonoBehaviour
{
    // Start is called before the first frame update
    Text mode;
    public AudioClip a1, a2;
    static bool destroy = false, a = false, first = true;
    GameObject str, m1, m2, txt, des, DES, cover;
    AudioSource As;
    void Start()
    {
        As = GetComponent<AudioSource>();
        /*if (SceneManager.GetActiveScene().name == "main")
        {
            str.GetComponent<Button>().onClick.AddListener(start);
            m2.GetComponent<Button>().onClick.AddListener(mode2);
            m1.GetComponent<Button>().onClick.AddListener(mode1);
        }*/
        if (first)
        {
            gameObject.name = "fixed";
            first = false;
        }
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "main")
        {
            str = GameObject.Find("/Canvas/start");
            txt = GameObject.Find("/Canvas/Text");
            m1 = GameObject.Find("/Canvas/m1");
            m2 = GameObject.Find("/Canvas/m2");
            des = GameObject.Find("/Canvas/des");
            DES = GameObject.Find("/Canvas/DES");
            cover = GameObject.Find("/Canvas/cover");
            str.GetComponent<Button>().onClick.AddListener(start);
            m2.GetComponent<Button>().onClick.AddListener(mode2);
            m1.GetComponent<Button>().onClick.AddListener(mode1);
            des.GetComponent<Button>().onClick.AddListener(destination);
            mode = txt.GetComponent<Text>();
        }
        Debug.Log(GameObject.Find("/Canvas/m2"));
        Debug.Log(m2.GetComponent<Button>().onClick.GetHashCode());
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "success")
        {
            destroy = true;
            a = true;
        }
        if(SceneManager.GetActiveScene().name == "main" && destroy && gameObject.name != "fixed")
        {
            Destroy(gameObject);
            destroy = false;
        }
       if(SceneManager.GetActiveScene().name == "main" && gameObject.name == "fixed" && a)
        {
            a = false;
            str = GameObject.Find("/Canvas/start");
            txt = GameObject.Find("/Canvas/Text");
            m1 = GameObject.Find("/Canvas/m1");
            m2 = GameObject.Find("/Canvas/m2");
            des = GameObject.Find("/Canvas/des");
            DES = GameObject.Find("/Canvas/DES");
            cover = GameObject.Find("/Canvas/cover");
            str.GetComponent<Button>().onClick.AddListener(start);
            m2.GetComponent<Button>().onClick.AddListener(mode2);
            m1.GetComponent<Button>().onClick.AddListener(mode1);
            des.GetComponent<Button>().onClick.AddListener(destination);
            mode = txt.GetComponent<Text>();
        }
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name != "main")
        {
            destroy = true;
            a = true;
        }
    }

    public void start()
    {
        if (mode.text == "NORMAL MODE") SceneManager.LoadScene("game");
        else if (mode.text == "NIGHTMARE !") SceneManager.LoadScene("game2");
        Debug.Log("fad");
    }
    public void mode1()
    {
        mode.text = "NORMAL MODE";
        As.clip = a1;
        As.Play();
    }
    public void mode2()
    {
        mode.text = "NIGHTMARE !";
        As.clip = a2;
        As.Play();
    }
    public void destination()
    {
        if (DES.GetComponent<Text>().color.a == 1)
        {
            DES.GetComponent<Text>().color -= new Color(0, 0, 0, 1);
            cover.GetComponent<Image>().color -= new Color(0, 0, 0, 0.63f);
            cover.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            DES.GetComponent<Text>().color += new Color(0, 0, 0, 1);
            cover.GetComponent<Image>().color += new Color(0, 0, 0, 0.63f);
            cover.GetComponent<Image>().raycastTarget = true;

        }
    }
}
