using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    [SerializeField]
    private float range; // 습득 가능한 최대 거리.

    private bool pickupActivated = false; // 습득 가능할 시 true.

    private RaycastHit hitInfo; // 충돌체 정보 저장.


    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Inventory theInventory;
    
    public bool islightitemGet = false; //플래시아이템을 가졌는지
    public GameObject[] door = null;
    public GameObject Weapon = null;


    private void Start()
    {
        door = GameObject.FindGameObjectsWithTag("Door");
        Weapon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                if (hitInfo.transform.tag == "Pipe")
                {
                    pickitem();
                    Weapon.SetActive(true);

                }
                if (hitInfo.transform.tag == "FlashLight")
                {
                    pickitem();
                    islightitemGet = true;
                    
                }
                if (hitInfo.transform.tag == "redkey")
                {
                    pickitem();
                    for (int i = 0; i<door.Length; i++)
            
                        
                        door[i].GetComponent<MyDoorController>().redKey = false;

                   
                }
                if (hitInfo.transform.tag == "yellowkey")
                {
                    pickitem();
                    for (int i = 0; i < door.Length; i++)
                        door[i].GetComponent<MyDoorController>().yellowKey = false;

                }
                if (hitInfo.transform.tag == "bluekey")
                {
                    pickitem();
                    for (int i = 0; i < door.Length; i++)
                        door[i].GetComponent<MyDoorController>().blueKey = false;

                }

            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Pipe")
            {
                ItemInfoAppear();
            }
            if (hitInfo.transform.tag == "FlashLight")
            {
                ItemInfoAppear();
            }
            if (hitInfo.transform.tag == "redkey")
            {
                ItemInfoAppear();
            }
            if (hitInfo.transform.tag == "bluekey")
            {
                ItemInfoAppear();
            }
            if (hitInfo.transform.tag == "yellowkey")
            {
                ItemInfoAppear();
            }

        }
        else
            InfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
    }
    
    
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void pickitem()
    {
        Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득했습니다");
        theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
        Destroy(hitInfo.transform.gameObject);
        InfoDisappear();
    }
   
}
