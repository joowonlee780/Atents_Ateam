using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrap : MonoBehaviour
{
    private PlayerHitManage pm;
    private bool isIn = true;
    float time = 0;
    
    private void Start()
    {
        pm = FindObjectOfType<PlayerHitManage>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 4.0f && isIn)
        {
            pm.Hit(3.0f);
            time = 0;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isIn = false;
    }
}
