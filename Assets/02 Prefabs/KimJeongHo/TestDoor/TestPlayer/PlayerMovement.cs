using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // 테스트용 입니다.
    Animator _amimator;
    Camera _camera;
    CharacterController _contorller;

    public bool toggleCameraRotation; // 주변 둘러보기
    public bool run;

    public float smoothness = 10f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 5f;
    public float runSpeed = 8f;
    public float finalSpeed;
    private float horizantalInput = 0f;
    private float verticalInput = 0f;

    public bool jDown;
    public bool isJump;
    public float jumpPower = 15f;

    public bool isRoll;

    void Start()
    {
        _amimator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _contorller = this.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovement();
        Jump();
        Roll();
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        }
        else
        {
            toggleCameraRotation = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
    }

    //private void FixedUpdate()
    //{
    //    Vector3 movement = new Vector3(movementX, 0f, movementY);
    //    rb.AddForce(movement * speed)
    //}

    private void LateUpdate()
    {
        if (toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

    public void isMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        horizantalInput = input.x;
        verticalInput = input.y;
    }

    void GetMovement()
    {
        finalSpeed = (run) ? runSpeed : speed;
        jDown = Input.GetButtonDown("Jump");

        Vector3 moveVector = new Vector3(horizantalInput, verticalInput);

        if (run)
        {
            transform.Translate(Vector3.forward * runSpeed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * runSpeed * horizantalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizantalInput * Time.deltaTime);
        }

        //Vector3 moveDirection 

        float percent = ((run) ? 1 : 0.5f) * Mathf.Abs(horizantalInput) + Mathf.Abs(verticalInput);
        _amimator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }

    void Jump()
    {
        if(jDown && !isJump)
        {
            rb.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            _amimator.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Roll()
    {
        if (jDown && !isJump)
        {
            speed *= 2;
            _amimator.SetTrigger("doJump");
            isRoll = true;

            Invoke("RollOut", 0.4f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
        }
    }

    void RollOut()
    {
        speed *= 0.5f;
        isRoll = false;
    }

}
 