using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    private Animator _animator;

    public GameObject OpenPanel = null;
    public GameObject ClosePanel = null;

    public bool openCheck;

    void Start()
    {
        _animator = transform.Find("Door").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Open", false);
            OpenPanel.SetActive(false);
        }
    }

    //private bool isopenpanelactive
    //{
    //    get
    //    {
    //        return openpanel.activeinhierarchy;
    //    }
    //}

    //private void update()
    //{
    //    if (isopenpanelactive)
    //    {
    //        if (input.getkeydown(keycode.e))
    //        {
    //            openpanel.setactive(false);
    //            _animator.setbool("open", true);
    //        }
    //    }
    //}
}
