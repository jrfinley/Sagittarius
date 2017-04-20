﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EndSequence : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}