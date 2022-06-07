using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool sampleDoor = false;
        [SerializeField] private bool sampleKey = false;

        [SerializeField] private KeyInventory _keyinventory = null; // KeyInventory.cs에서 옵션을 가져오게 하는 변수

        private KeyDoorController doorObject;

        private void Start()
        {
            if (sampleDoor)
            {
                //doorObject = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if(sampleDoor)
            {
                doorObject.PlayAnimation();
            }

            else if(sampleKey)
            {
                _keyinventory.startPointKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
