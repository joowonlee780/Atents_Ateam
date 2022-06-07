using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCheetController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Vector3 openPostion, closePosition;    

    public bool doorOpen = false;

    public GameObject OpenPanel = null;
    public GameObject ClosePanel = null;

    private DoorRaycast theDoorRayCast;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        OpenPanel.SetActive(false);
        ClosePanel.SetActive(false);
    }

    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            transform.position = openPostion;
            doorOpen = false;
            ClosePanel.SetActive(true);
        }
        else
        {
            transform.position = closePosition;
            ClosePanel.SetActive(false);
        }
    }
}
