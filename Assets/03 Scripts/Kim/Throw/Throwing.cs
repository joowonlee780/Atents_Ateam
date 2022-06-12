using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    //참고자료
    //차징 관련 : https://www.youtube.com/watch?v=2BJyG54eP4w
    //던지기 관련 : https://www.youtube.com/watch?v=F20Sr5FlUlE

    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Setting")]
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public bool readyToThrow;
    public bool haveThrows;
    public bool ChargeThrow;

    //차지 관련
    public const float Max_Force = 100f;
    private float holdDownStartTime;
    private float weakPower = 0.1f;

    //필요한 컴포넌트
    [SerializeField] private ChargeThrow theCharge;

    private void Start()
    {
        haveThrows = false;
        readyToThrow = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(throwKey) && haveThrows)
        {
            holdDownStartTime = Time.time;
            ChargeThrow = true;
        }
        if(Input.GetKeyUp(throwKey) && readyToThrow && haveThrows)
        {
            float holdDownTime = Time.time - holdDownStartTime;
            Throw(holdDownTime);
            theCharge.chairObj.SetActive(false);
        }
    }

    public void Throw(float HoldTime)
    {
        float maxForceHoldDownTime = 1.5f;
        float holdTimeNormalized = Mathf.Clamp01(HoldTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * Max_Force;

        ChargeThrow = false;
        readyToThrow = false;
        haveThrows = false;

        theCharge.anim.SetBool("ReadyThrow", false);

        //instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        projectile.GetComponent<ObjectController>().inspectController =
            GameObject.FindGameObjectWithTag("Inspect").gameObject.GetComponent<InspectController>();
        //get rigidbodt component
        Rigidbody porjectileRb = projectile.GetComponent<Rigidbody>();

        //calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position,cam.forward,out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        //add force
        Vector3 forceToAdd = forceDirection * force * weakPower + transform.up * throwUpwardForce;

        porjectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    public void ResetThrow()
    {
        readyToThrow = true;
    }

    public void ThrowOn()
    {
        if(!haveThrows)
        haveThrows = !haveThrows;
    }
}
