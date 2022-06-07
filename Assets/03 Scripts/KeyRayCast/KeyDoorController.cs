using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTime = 1;
        [SerializeField] private bool pauseInteraction = false;


        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTime);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if(_keyInventory.hassampleKey)
            {
                OpenDoor();
            }

            //else if (_keyInventory.redKey) 색깔 하나씩 추가 할 때마다 적용
            //{
            //    OpenDoor();
            //}



            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);
        }
    }
}

/*
 첫 번째 매개변수 : stateName
 두 번째 매개변수 : layer
 세 번쨰 매개변수 : normalizedTime
 
 첫 번쨰 매개변수로는 Play할 애니메이션 state의 이름을 적는다.
 두 번째 매개변수로는 layer를 설정한다. -1일 경우 첫 state를 재생한다.
 세 번째 매개변수로는 normalizedTime를 적는다.
 
 normalizedTime란, 표준화된(normalized) 애니메이션 시간아다. 
 값 1은 애니메이션의 끝을 의미하며 값 0.5는 애니메이션의 중간을 의미한다.
 

 출처: https://codingmania.tistory.com/213 [개발자의 개발 블로그]
*/
