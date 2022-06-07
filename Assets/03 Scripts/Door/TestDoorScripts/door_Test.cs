using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_Test : MonoBehaviour
{
    private Animator anim = null;
    public GameObject OpenPanel = null;
    public GameObject ClosePanel = null;
    public bool openDoor = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        OpenPanel.SetActive(false);
        ClosePanel.SetActive(false);
        //ClosePanel.SetActive(false);
        //eDown = Input.GetKeyDown(KeyCode.E);
    }

    public void open(bool front)
    {
        if (front)
        {
            anim.SetTrigger("OpenB");
        }
        else
        {
            anim.SetTrigger("Open");
        }
    }

    void close()
    {
        anim.SetTrigger("Close");
        OpenPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(CheckFront(other.transform));
        if (other.CompareTag("Player"))
        {
            //bool front = CheckFront(other.transform);
            //open(front);
            if (openDoor == false)
            {
                OpenPanel.SetActive(true);
            }
            else
            {
                ClosePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // OpenPanel.SetActive(true);
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (openDoor == false)
            {
                bool front = CheckFront(other.transform);
                open(front);
                openDoor = true;
                OpenPanel.SetActive(false);
            }
            else 
            {
                close();
                openDoor = false;
            }  
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (openDoor == false)
    //        {
    //            if (other.CompareTag("Player"))
    //            {
    //                bool front = CheckFront(other.transform);
    //                open(front);
    //                openDoor = true;
    //            }
    //            else
    //            {
    //                close();
    //                openDoor = false;
    //            }
    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenPanel.SetActive(false);
            ClosePanel.SetActive(false);
        }
    } //4.18 수정

    bool CheckFront(Transform target)
    {
        bool result = false;
        Vector3 dir = transform.position - target.position;

        float angle = Vector3.Angle(dir, transform.forward);

        if( angle > 90f && angle < 180f)
        {
            result = true;
        }

        return result;
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }
}
