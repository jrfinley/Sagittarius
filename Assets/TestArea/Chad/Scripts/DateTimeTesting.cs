using UnityEngine;
using System;
using System.Collections;

public class DateTimeTesting : MonoBehaviour
{
    DateTime currentTime = new DateTime();

    private void Start()
    {
        currentTime = DateTime.Now;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentTime = currentTime.AddHours(1);
            print(currentTime);
        }
    }
}
