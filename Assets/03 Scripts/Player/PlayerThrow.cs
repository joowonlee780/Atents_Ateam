using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject throwPosition; //벽돌이나 공병을 발사할 위치
    public GameObject throwFactory; //무기 오브젝트
    public float throwPower = 15.0f;
    public Camera Camera;

    public bool isHave = false;

    // Update is called once per frame
    void Update()
    {
        if (isHave)
        {
            // 마우스 버튼을 통해 벽돌이나 공병 던지기
            if (Input.GetMouseButtonDown(0)) //좌:0 ,우:1, 휠:2
            {
                GameObject bottle = Instantiate(throwFactory);
                bottle.transform.position = throwPosition.transform.position;
                Rigidbody rb = bottle.GetComponent<Rigidbody>();

                // 카메라 정면 방향으로 병에 물리적 힘을 가함
                rb.AddForce(Camera.transform.forward * throwPower, ForceMode.Impulse);

                isHave = false;
            }
        }
    }
}
