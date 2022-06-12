using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private string itemName;

    [TextArea] [SerializeField] private string itemExtraInfo;
    [TextArea] [SerializeField] private string ClipBoardExtraInfo;
    
    [TextArea] [SerializeField] private string NPC_Skeleton_Name_ExtraInfo; // 스켈레톤용
    [TextArea] [SerializeField] private string NPC_Skeleton_Contents_ExtraInfo; // 스켈레톤용
    [TextArea] [SerializeField] private string NPC_Skeleton_Ekey_ExtraInfo; // 스켈레톤용


    [SerializeField] public InspectController inspectController;

    ////사운드
    //[SerializeField] public string readObjectAudio;
    //[SerializeField] public string nonReadObjectAudio;

    public void ShowObjectName()
    {
        inspectController.ShowName(itemName);
    }

    public void HideObjectName()
    {
        inspectController.HideName();
    }

    public void ShowExtraInfo()
    {
        inspectController.ShowAddtionalInfo(itemExtraInfo);
    }

    public void ShowClipBoard()
    {
        inspectController.ShowClipBoard(ClipBoardExtraInfo);
    }

    public void ShowNPC() // 해골용
    {
        inspectController.ShowNPCClipBoardName(NPC_Skeleton_Name_ExtraInfo); // inspectController에 있는 함수를 선언해서 NPC_Skeleton_Name_ExtraInfo를 넣어줌 
        inspectController.ShowNPCClipBoardContent(NPC_Skeleton_Contents_ExtraInfo); // inspectController에 있는 함수를 선언해서 NPC_Skeleton_Contents_ExtraInfo
        inspectController.ShowNPCClipBoardPressE(NPC_Skeleton_Ekey_ExtraInfo); // inspectController에 있는 함수를 선언해서  NPC_Skeleton_Ekey_ExtraInfo
    }
}

