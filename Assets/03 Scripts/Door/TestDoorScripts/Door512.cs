using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door512 : MonoBehaviour
{
    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TryOpenDoor()
    {
        Debug.Log("문열기");
    }

    public void TryCloseDoor()
    {
        Debug.Log("문닫기");
    }
}
