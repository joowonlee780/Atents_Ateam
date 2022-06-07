using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private Animator anim = null;
    public GameObject OpenPanel = null;
    public GameObject ClosePanel = null;
    public bool openDoor = false;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

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

    private void OnTriggerStay(Collider other)
    {
        // OpenPanel.SetActive(true);
        if (other.CompareTag("Player") && Input.GetKeyDown(openDoorKey))
        {
            if (!openDoor)
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
            if (!openDoor)
            {
                OpenPanel.SetActive(true);
            }
            else
            {
                ClosePanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenPanel.SetActive(false);
            ClosePanel.SetActive(false);
        }
    }

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
