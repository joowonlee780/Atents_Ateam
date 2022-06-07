using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private Animator anim = null;
    public bool openDoor = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void open(bool front)
    {
        if (front)
        {
            anim.SetBool("Open", false);
            anim.SetBool("Close", false);
            anim.SetBool("OpenB", true);
        }
        else
        {
            anim.SetBool("OpenB", false);
            anim.SetBool("Close", false);
            anim.SetBool("Open", true);
        }
    }

    void close()
    {
        anim.SetBool("OpenB", false);
        anim.SetBool("Open", false);
        anim.SetBool("Close",true);
    }

    private void OnTriggerStay(Collider other)
    {
        // OpenPanel.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
        {
            Debug.Log("시도");
            if (!openDoor)
            {
                Debug.Log("실제로 문 닫힘");
                bool front = CheckFront(other.transform);
                open(front);
                openDoor = true;
            }
            else
            {
                Debug.Log("실제로 문 열림");
                close();
                openDoor = false;
            }
        }
    }

    bool CheckFront(Transform target)
    {
        bool result = false;
        Vector3 dir = transform.position - target.position;

        float angle = Vector3.Angle(dir, transform.forward);

        if (angle > 90f && angle < 180f)
        {
            result = true;
        }

        return result;
    }
}