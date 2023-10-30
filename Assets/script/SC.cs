using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) SceneManager.LoadScene("main");
    }
}
