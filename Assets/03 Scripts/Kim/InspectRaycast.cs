using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private InspectController inspectController;
    [SerializeField] private Throwing theThrowing;
    [SerializeField] private Door512 doorController;

    [SerializeField] private int rayLength = 5; // 범위
    [SerializeField] private LayerMask layerMaskInteract;

    private ObjectController raycastedObj;

    // 크로스 헤어 관련
    [SerializeField] private Image crosshair;
    public GameObject Throwing;
    private bool isCrosshairActive;

    // 레이케스트 범위 조건
    private bool doOnce;

    // ClipBoard 관련
    public bool boardOn = false;

    // NPC 관련
    public bool SkeletonOn = false;

    // Door 관련
    public bool isEnterFront = false;
    private bool isOpen = false;

    private void Update()
    {
        ShowInteractObject();
        ShowClipBoard();
        ShowNPCSkeleton();
        ShowThrowObjects();
    }

    void ShowInteractObject()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.T))
                {
                    Debug.Log("실험중");
                    raycastedObj.ShowExtraInfo();
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void ShowClipBoard()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("ClipBoard"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                }
                isCrosshairActive = true;

                doOnce = true;
                if (Input.GetKeyDown(KeyCode.E) && !boardOn)
                {
                    raycastedObj.ShowClipBoard();
                    boardOn = true;
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
            if(Input.GetKeyDown(KeyCode.E) && boardOn)
            {
                inspectController.HideClipBoard();
                boardOn = false;
            }
        }
    }

    void ShowNPCSkeleton()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Skeleton"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                    Debug.Log("스켈레톤");
                }
                isCrosshairActive = true;

                doOnce = true;
                if (Input.GetKeyDown(KeyCode.E) && !SkeletonOn) // 시체를 보고 E키를 누름
                {
                    raycastedObj.ShowNPC(); // 여기에 시체가 있다... 오래 된 것 같다...
                    SkeletonOn = true;
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && SkeletonOn) // 시체 E키를 누른 상태 (무언가 정보가 있다.)
            {
                inspectController.HideNPCClipBoard();
                Debug.Log("꺼지니?");
                SkeletonOn = false;
            }
        }
    }

    void ShowThrowObjects()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Throw"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("여기에서 줍기 on & 오브잭트 파괴");
                    Destroy(hit.collider.gameObject);
                    theThrowing.ThrowOn(); // on
                    raycastedObj.ShowExtraInfo();
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    protected void CheckFront(Transform target)   // target은 문으로 들어가려는 오브젝트의 트랜스폼
    {
        Vector3 dir = transform.position - target.position;     // 문으로 진입하는 방향벡터 구하기
        float angle = Vector3.Angle(dir, transform.forward);    // 진입 방향벡터와 문의 forward 벡터의 사이각 구하기
        if (angle > 90.0f && angle < 180.0f)    // 사이각이 둔각일 경우
        {
            isEnterFront = true;    //문 앞에 있는 것으로 판정
        }
        else
        {
            isEnterFront = false;   //문 뒤에 있는 것으로 판정
        }
    }

    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            crosshair.color = Color.yellow;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
