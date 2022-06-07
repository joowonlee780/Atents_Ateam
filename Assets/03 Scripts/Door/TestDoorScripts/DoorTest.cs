using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour
{
    private Animator anim = null;
    public bool openDoor = false;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(openDoorKey))
        {
            if (!openDoor)
            {
                Open();
            }
            else
            {
                close();
            }
        }
    }
    void Open()
    {
        anim.SetTrigger("OpenB");
        openDoor = true;
    }
    
    void close()
    {
        anim.SetTrigger("Close");
        openDoor = false;
    }
}

