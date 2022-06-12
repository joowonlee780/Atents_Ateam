using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeThrow : MonoBehaviour
{
    public Animator anim;
    [SerializeField] public GameObject chairObj;

    //원래 의자 위치
    //[SerializeField] public GameObject org_rot;

    //필요한 컴포넌트
    [SerializeField] private Throwing theThrowing;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Charge();
    }

    private void Charge()
    {
        if(theThrowing.ChargeThrow)
        {
            anim.SetBool("ReadyThrow", true);
        }
        else
        {
            anim.SetBool("ReadyThrow", false);
        }
    }
}
