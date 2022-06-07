using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem // namespace를 사용하여 스크립트의 중복된 내용 충돌 방지
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;                 // 화면과 키 사이 거리?
        [SerializeField] private LayerMask layerMskInteract;        // 레이어2
        [SerializeField] private string exclusetLayerName = null;   // 레이어1

        private  KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.E; // 키 열때 E키

        [SerializeField] private Image crosshair = null;            // 크로스헤어
        private bool isCrosshairActive;                             // 크로스헤어 변경 
        private bool doOnce;

        private string interactableTag = "Item";

        private void Update()
        {
            RaycastHit hit;                                              // RaycastHit 충돌체의 정보를 받을 변수
            Vector3 fwd = transform.TransformDirection(Vector3.forward); // 로컬 좌표계에서 월드 좌표계로 변환

            // 복수의 레이어를 원할 경우 1 << (레이어1) | (레이어2)의 형태로 비트or 연산을 추가하면 된다.
            int mask = 1 << LayerMask.NameToLayer(exclusetLayerName) | layerMskInteract.value;

            // raycast 사용중 자신과 타겟사이에 오브젝트가 끼어들어도 계속 타겟에게 ray를 쏘고 싶을 때 사용
            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))  // 키보드 E키
                    {
                        raycastedObject.ObjectInteraction(); // KeyItemController에서 만든 공개 메소드 ObjectInteraction();
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
        }
        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}


/*
Raycast 함수에 필요한 매개변수는 다음과 같다.
Ray 충돌을 검출할 직선 (Vector 두개로 시점과 방향벡터를 넣을 수도 있다)
RaycastHit 충돌체의 정보를 받을 변수 
float 탐지거리
int 레이어 마스크(layerMask)
이 중 레이어 마스크는 원하는 레이어의 충돌체만 검출하고 싶을 때 사용하는 변수이며, 비트값으로 이용한다.
원하는 특정 레이어만 검출하는 마스크를 생성하기 위해선
1<<LayerMask.NameToLayer("원하는 레이어 이름") 의 비트연산을 하게된다.
복수의 레이어를 원할 경우엔
1 << (레이어1) | (레이어2) 의 형태로 비트or 연산을 추가하면 된다.
반대로 특정 레이어만 제외한다면 위와 같이 계산된 레이어 마스크의 비트를 부정한다. (Not 연산)
~( 1 << (레이어) )
혹은 -1에서 빼도 같은 결과가 산출된다.
-1 - ( 1 << (레이어) )

 // 출처 : https://hwoongg.tistory.com/13
*/