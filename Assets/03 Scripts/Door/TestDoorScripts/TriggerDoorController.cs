using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string doorOpen = "DoorOpenFront";
    [SerializeField] private string doorClose = "DoorCloseFront";


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                myDoor.Play("DoorOpenFront", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if(closeTrigger)
            {
                myDoor.Play("DoorCloseFront", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
