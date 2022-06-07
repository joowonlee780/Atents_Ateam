using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier_Trap : MonoBehaviour
{
    public GameObject chandelier;

    // 샹들리에 사운드 
    public AudioSource audioSource;
    public AudioClip audioClip;

    // 바닥 오브젝트
    private GameObject floor;

    private Rigidbody rigid = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        // audioSource = GetComponent<AudioSource>();
        // rigid.useGravity = false;
    }

    //private void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    audioClip = Resources.Load<AudioClip>("Chandelier/ChandelierBroken"); // 깨지는 소리 찾기
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Player"))
        {
            rigid.useGravity = true;

            StartCoroutine(chandelierSound());
        }


    }

    IEnumerator chandelierSound()
    {
        yield return new WaitForSeconds(1.0f);

        audioSource.clip = audioClip;
        audioSource.Play();
        Debug.Log("사운드사운드");
    }

    //public void SoundPlay()
    //{
    //    audioSource.PlayOneShot(audioClip);
    //}

    

}
