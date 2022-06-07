using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SCPAI : MonoBehaviour {
    public enum SCPState
    {
        IDLE,
        ATTACK,
        DIE
    }

   
    public SCPState state = SCPState.IDLE;

    public AudioClip idle, die, attack;
    public AudioSource audio;
    
    private Transform playerTr;
    private Transform enemyTr;
    private Animator animator;
    public float attackDist = 6.0f;
    public bool isDie = false;
    private WaitForSeconds ws;
    private SCPAttack enemyFire;

    
    private readonly int hashDie = Animator.StringToHash("Die");

    
    public Light PlayerLight;
    
    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTr = player.GetComponent<Transform>();
        enemyTr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        enemyFire = GetComponent<SCPAttack>();
        
        ws = new WaitForSeconds(0.5f);
    }

    void OnEnable()
    {
        StartCoroutine(CheckState());
        StartCoroutine(Action());
    }

    IEnumerator CheckState()
    {
        while (!isDie)
        {
            if (state == SCPState.DIE)
            {                   
                
                yield break;
            }
            
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            
            if (isLight() &&  dist <= attackDist)
            {
                state = SCPState.ATTACK;
            }
            else if (dist >= attackDist)
                state = SCPState.IDLE;
            else
            {
                state = SCPState.IDLE;
            }
            yield return ws;
        }
    }

    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;

            switch (state)
            {
                case SCPState.IDLE:
                    if(enemyFire.isFire == true);   
                        enemyFire.isFire = false;
                    enemyIdleSound();
                    break;
                case SCPState.ATTACK:
                    if (enemyFire.isFire == false)
                        enemyFire.isFire = true;
                    enemyAttackSound();
                    break;
                case SCPState.DIE:
                    isDie = true;
                    enemyDieSound();
                    enemyFire.isFire = false;
                    animator.SetTrigger(hashDie);
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }
        }

    }
    private void Update()
    {
        //animator.SetFloat(hashSpeed,moveAgent.speed);
    }

    private bool isLight()
    {
        if (PlayerLight.intensity > 4.0f) return true;

        return false;
    }
    
    void enemyIdleSound()
    {
        if(audio.clip == attack && audio.isPlaying) audio.Stop();
        if(audio.isPlaying) return;
        audio.clip = idle;
        audio.Play();
    }

    void enemyDieSound()
    {
        if(audio.clip == attack && audio.isPlaying) audio.Stop();
        if(audio.isPlaying) return;
        audio.clip = die;
        audio.Play();
    }
    
    void enemyAttackSound()
    {
        if(audio.clip == idle && audio.isPlaying) audio.Stop();
        
        if(audio.isPlaying) return;
        audio.clip = attack;
        audio.Play();
    }
}
