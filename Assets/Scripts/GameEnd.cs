﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    CheckKeys();
    }

    void CheckKeys(){
        if(Input.anyKey){
            SceneManager.LoadScene(3);
        }
        }
}
