using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerHitManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitScreen; // 피격 시 보여질 화면
    public GameObject bloodyScreen; // 일정 hp 이하로 떨어지면 보여질 화면
    private float h_alpha_color; // 생동감을 주기 위한 알파값
    Image img; // 실제 이미지(피격)

    public float hp;
    //private GameOver GameOverManager;
    public PlayerHealth playerHP = null;
    
    AudioSource[] playerAudioSource;
    // 1번이 피격음, 2번이 심장소리, 3번이 신음소리
    private AudioSource hitSound;
    private AudioSource heartbeatSound;
    private AudioSource breathSound;

    //private Animator animator;
    
    public Text healthText = null;
    public Slider healthSlider = null;

    private void Awake()
    {
        //GameOverManager = GetComponent<GameOver>();
        //animator = GetComponentInParent<Animator>();
        this.playerAudioSource = GetComponents<AudioSource>();

        
        hitSound = playerAudioSource[0];
        heartbeatSound = playerAudioSource[1];
        breathSound = playerAudioSource[2];
        
    }
    void Start()
    {
        hitScreen.SetActive(false);
    }

    public void Hit() // 맞았을때 호출됨
    {       
        //깜박거리게 한다.
        StartCoroutine("PlayerHit"); // 이 코루틴에서 hp가 줄어듬
    }

    IEnumerator PlayerHit()
    {
        h_alpha_color = 1.0f; // 알파값은 처음엔 1로
        //hitScreen을 보이게 한다.
        hitScreen.SetActive(true);
        
        //hp -= 5f;
        playerHP.health -= 5f;
        
        //if (hp <= 0f) hp = 0f;
        if (playerHP.health <= 0f) playerHP.health = 0f;
        Debug.Log( playerHP.health);
        healthSlider.value = playerHP.health / playerHP.maxHealth;
        healthText.text = $"{playerHP.health}/{playerHP.maxHealth}";
        StopHitAudio(); // 이전에 재생중이었다면 끄고
        PlayHitAudio(); // 다시 맞는 소리 시작
        while (h_alpha_color > 0) // 알파값이 0 즉, 거의 다 사라져 안보일 때 까지 반복
        {
            h_alpha_color -= 0.01f; // 점점 옅어진다

            yield return new WaitForSeconds(0.01f); // 딜레이는 0.01초
            img = hitScreen.GetComponent<Image>(); // 이미지를 가져와
            img.color = new Color(255, 255, 255, h_alpha_color); // 알파값을 변경
        }
        //hitScreen을 안보이게 한다.
        hitScreen.SetActive(false);
    }
    void BloodyScreenOn()
    {
       // bloodyScreen = this.transform.GetChild(1).gameObject;

        if (bloodyScreen.activeSelf == false)
        {
            PlayFatalAudio();
            bloodyScreen.SetActive(true);

        }

    }

    void BloodyScreenOff()
    {
       // bloodyScreen = this.transform.GetChild(1).gameObject;

        if (bloodyScreen.activeSelf == true)
        {
            StopFatalAudio();
            bloodyScreen.SetActive(false);
        }

    }

    

    void PlayHitAudio()
    {
        hitSound.Play();
    }

    void StopHitAudio()
    {
        hitSound.Stop();
    }

    void PlayFatalAudio()
    {
        heartbeatSound.Play();
        breathSound.Play();
    }

    void StopFatalAudio()
    {
        heartbeatSound.Stop();
        breathSound.Stop();
    }

    void PlayerDead()
    {
        StopFatalAudio();
    }

    void Update()
    {
        if ( playerHP.health <= 30f) BloodyScreenOn();
        else BloodyScreenOff();

        if ( playerHP.health <= 0) // 죽었을 때 연출 할 부분
        {
            PlayerDead(); // 플레이어를 죽음으로 설정
        }
    }
}
