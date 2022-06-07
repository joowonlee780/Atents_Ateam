using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f; // �÷��̾ ����� �� �ִ� ���¹̳� ��ġ
    [SerializeField] private float maxStamina = 100.0f; // �÷��̾� ���¹̳� �ִ�ġ
    [HideInInspector] public bool hasRegenerated = true; // ���¹̳� ȸ��
    [HideInInspector] public bool playerRunning = false; // �÷��̾ ���� �޸��°� WeAreSprinting = playerRunning

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] private float staminaDrain = 0.5f; // ���¹̳� �Ҹ�
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f; // ���¹̳� �ڿ� ȸ����

    [Header("Stamina Speed Parameters")]
    [SerializeField] private float slowedRunSpeed = 8.0f; // ���¹̳� �� �Ҹ��ؼ� ������ �޸��� �ӵ�
    [SerializeField] private float normalRunSpeed = 15.0f; // ���¹̳� �Ἥ �޸� ���� �޸��� �ӵ�

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
                playerStamina += staminaRegen * Time.deltaTime; // ���¹̳� ������Ʈ
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
                hasRegenerated = false; // �÷��̾� ������
                playerController.SetRunSpeed(slowedRunSpeed);
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int value) // ���¹̳� UI ������Ʈ
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
