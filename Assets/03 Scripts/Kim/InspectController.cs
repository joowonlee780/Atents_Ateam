using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private Door512 doorObj;

    [SerializeField] private float onScreenTimer;
    [SerializeField] public bool startTimer;

    [SerializeField] private GameObject objectNameBG;
    [SerializeField] private Text objectNameUI;

    [SerializeField] private GameObject extraInfoBG; // 바꿈
    [SerializeField] private Text extraInfoUI; // 바꿈

    [SerializeField] private GameObject ClipBoardBG;
    [SerializeField] private Text ClipBoardUI;

    [SerializeField] private GameObject NPC_SitSkeletonBG;
    [SerializeField] private Text NPC_SitSkeletonNameUI;                // NPC 이름
    [SerializeField] private Text NPC_SitSkeletonContentsUI;            // NPC 설명
    [SerializeField] private Text NPC_SitSkeleton_EkeyUI;               // NPC E키 누르면 다음으로 넘어가도록 설명


    private float timer;

    private void Start()
    {
        objectNameBG.SetActive(false);
        extraInfoBG.SetActive(false);
        ClipBoardBG.SetActive(false); // 바꿈
        NPC_SitSkeletonBG.SetActive(false);
    }

    private void Update()
    {
        if(startTimer)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                timer = 0;
                ClearAdditionalInfo();
                startTimer = false;
            }
        }
    }

    public void ShowName(string objectName)
    {
        objectNameBG.SetActive(true);
        objectNameUI.text = objectName;
    }

    public void HideName()
    {
        objectNameBG.SetActive(false);
        objectNameUI.text = "";
    }

    public void ShowAddtionalInfo(string newInfo)
    {
        timer = onScreenTimer;
        startTimer = true;
        extraInfoBG.SetActive(true);
        extraInfoUI.text = newInfo;
    }

    public void ClearAdditionalInfo()
    {
        extraInfoBG.SetActive(false);
        extraInfoUI.text = "";
    }

    public void ShowClipBoard(string newInfo)
    {
        timer = onScreenTimer;
        startTimer = true;
        ClipBoardBG.SetActive(true);
        ClipBoardUI.text = newInfo;
    }

    public void HideClipBoard()
    {
        ClipBoardBG.SetActive(false);
        ClipBoardUI.text = "";
    }

    // 20220529_NPC 스켈레톤 추가

    public void ShowNPCClipBoardName(string newInfo) // 이름에 관련
    {
        timer = onScreenTimer;
        startTimer = true;
        NPC_SitSkeletonBG.SetActive(true); // 백그라운드
        NPC_SitSkeletonNameUI.text = newInfo;
    }

    public void ShowNPCClipBoardContent(string newInfo) // 문구 내용에 관련
    {
        timer = onScreenTimer;
        startTimer = true;
        NPC_SitSkeletonContentsUI.text = newInfo;
    }

    public void ShowNPCClipBoardPressE(string newInfo) // E키 관련
    {
        timer = onScreenTimer;
        startTimer = true;
        NPC_SitSkeleton_EkeyUI.text = newInfo;
    }

    public void HideNPCClipBoard()
    {
        NPC_SitSkeletonBG.SetActive(false);
        NPC_SitSkeletonNameUI.text = "";
        NPC_SitSkeletonContentsUI.text = "";
        NPC_SitSkeleton_EkeyUI.text = "";
    }
}
