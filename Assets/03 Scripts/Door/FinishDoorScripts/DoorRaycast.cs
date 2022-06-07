using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] public int rayLenth = 5;
    [SerializeField] private LayerMask layerMasInteract;
    [SerializeField] private string excludeLayerName = null;

    //필요한 컴포넌트
    private MyDoorController raycastObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    [SerializeField] private Image crosshair = null;
    public bool isCrosshairActive;
    private bool doOnce;


    private const string doorTag = "Door";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMasInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLenth, mask))
        {
            if (hit.collider.CompareTag(doorTag))
            {
                if (!doOnce)
                {
                    raycastObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    CrosshairChange(true);

                    if (raycastObj.doorOpen && !raycastObj.redKey && !raycastObj.blueKey && !raycastObj.yellowKey)
                    {
                        raycastObj.OpenPanel.SetActive(false);
                        raycastObj.ClosePanel.SetActive(true);
                    }
                    else if (!raycastObj.doorOpen)
                    {
                        raycastObj.ClosePanel.SetActive(false);
                        raycastObj.OpenPanel.SetActive(true);
                    }
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    if (raycastObj.redKey)
                    {
                        Debug.Log("redkey가 없습니다.");
                    }
                    else if (raycastObj.blueKey)
                    {
                        Debug.Log("blueKey가 없습니다.");
                    }
                    else if (raycastObj.yellowKey)
                    {
                        Debug.Log("yellowKey가 없습니다.");
                    }
                    else
                    {
                        raycastObj.PlayAnimation();
                    }
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
                raycastObj.OpenPanel.SetActive(false);
                raycastObj.ClosePanel.SetActive(false);
            }
        }
    }

    public void CrosshairChange(bool on)
    {
        if (on && !doOnce)
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
