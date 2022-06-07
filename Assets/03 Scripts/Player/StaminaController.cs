using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f; // 플레이어가 사용할 수 있는 스태미나 수치
    [SerializeField] private float maxStamina = 100.0f; // 플레이어 스태미나 최대치
    [HideInInspector] public bool hasRegenerated = true; // 스태미나 회복
    [HideInInspector] public bool playerRunning = false; // 플레이어가 현재 달리는가 WeAreSprinting = playerRunning

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f; // 스태미나 소모량
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f; // 스태미나 자연 회복량

    [Header("Stamina Speed Parameters")]
    [SerializeField] private float slowedRunSpeed = 8.0f; // 스태미나 다 소모해서 느려진 달리기 속도
    [SerializeField] private float normalRunSpeed = 15.0f; // 스태미나 써서 달릴 때의 달리기 속도

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerRunning)
        {
            if(playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime; // 스태미나 업데이트
                UpdateStamina(1);

                if(playerStamina >= maxStamina)
                {
                    playerController.SetRunSpeed(normalRunSpeed);
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;
                }
            }
        }
    }

    public void Running()
    {
        if (hasRegenerated)
        {
            playerRunning = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if(playerStamina <= 0)
            {
                hasRegenerated = false; // 플레이어 느려짐
                playerController.SetRunSpeed(slowedRunSpeed);
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int value) // 스태미나 UI 업데이트
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if(value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }

        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
