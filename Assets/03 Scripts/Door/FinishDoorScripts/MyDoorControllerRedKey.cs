using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorControllerRedKey : MonoBehaviour
{
    public bool haveRedKey = false;

    private Animator anim;

    public bool doorOpen = false;

    public GameObject OpenPanel = null;
    public GameObject ClosePanel = null;

    private DoorRaycast theDoorRayCast;

    // 사운드
    [SerializeField] private string doorOpenAudio;
    [SerializeField] private string doorCloseAudio;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        OpenPanel.SetActive(false);
        ClosePanel.SetActive(false);
    }

    public void PlayAnimation()
    {
        if(!doorOpen && haveRedKey)
        {
            SoundManager.instance.playSE(doorOpenAudio);
            anim.SetTrigger("OpenB");
            doorOpen = true;
            OpenPanel.SetActive(false);
        }
        else
        {
            SoundManager.instance.playSE(doorCloseAudio);
            anim.SetTrigger("Close");
            doorOpen = false;
            ClosePanel.SetActive(false);
        }
    }
}
