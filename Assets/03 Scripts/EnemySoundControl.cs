using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySoundControl : MonoBehaviour
{
    // 피격, 사망, 공격 효과음 배열 선언
    public AudioClip[] damage, die, attack;

    // 오디오소스
    public AudioSource audio;
    
    // 효과음 랜덤 실행 시 필요한 변수, 실행 직전에 Random.Range를 이용함.
    private int soundNum;

    public enum EnemyState
    {
        IDLE,
        ATTACK,
        DIE,
        DAMAGE
    }
    public EnemyState activeState = EnemyState.IDLE;
    public SCPAI scpState;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        Debug.Log(scpState);
        switch (activeState)
            {
                case EnemyState.ATTACK:
                    //Debug.Log("공격"); // 공격 state 인지 확인하는 용도
                   enemyAttackSound();
                   break;
                case EnemyState.DIE:
                    //Debug.Log("사망");  // 사망 state 인지 확인하는 용도
                    enemyDieSound();
                    break;
                case EnemyState.DAMAGE:
                    //Debug.Log("피격"); // 피격 state 인지 확인하는 용도
                    enemyDamageSound();
                    break;
                default:
                    break;
            }
    }
    void enemyDamageSound()
    {
        // 피격 효과음 랜덤으로 재생하기 위해 랜덤 변수 사용
        soundNum = Random.Range(0, damage.Length);
        // 랜덤 피격 효과음 할당
        audio.clip = damage[soundNum];
        // 재생
        audio.Play();
    }

    void enemyDieSound()
    {
        // 사망 효과음 랜덤으로 재생하기 위해 랜덤 변수 사용
        soundNum = Random.Range(0, damage.Length);
        // 랜덤 사망 효과음 할당
        audio.clip = damage[soundNum];
        // 재생
        audio.Play();
    }
    
    void enemyAttackSound()
    {
        // 공격 효과음 랜덤으로 재생하기 위해 랜덤 변수 사용
        soundNum = Random.Range(0, damage.Length);
        // 랜덤 공격 효과음 할당
        audio.clip = damage[soundNum];
        // 재생
        audio.Play();
    }
}
