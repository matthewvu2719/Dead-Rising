using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontRightCollider;
    public WheelCollider frontLeftCollider;
    public WheelCollider backRightCollider;
    public WheelCollider backLeftCollider;

    [Header("Wheels Transform")]
    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;
    public Transform vehicleDoor;

    [Header("Vehicle Engine")]
    public float breakingForce = 200f;
    private float presentBreakForce = 0f;
    public float accelerationForce = 100f;
    private float presentAcceleration = 0f;

    [Header("Vehcile Steering")]
    public float wheelsTorque = 20f;
    private float presentTurnAngle = 0f;

    [Header("Vehicle Security")]
    public PlayerScript player;
    private float radius = 5f;
    private bool isOpened = false;

    [Header("Disable Thing")]
    public GameObject aimCam;
    public GameObject aimCanvas;
    public GameObject tpsCam;
    public GameObject tpsCanvas;
    public GameObject playerCharacter;

    [Header("Vehicle Hit Var")]
    public float hitRange = 2f;
    private float giveDamageOf = 100f;
   // public ParticleSystem hitSpark;
    public GameObject goreEffect;
    public GameObject destroyEffect;
    public Camera[] cam;
    public GameObject objectivesMenu;
    private bool completeObject3 = false;

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOpened = true;
                radius = 5000f;

                if (completeObject3 == false)
                {
                    Time.timeScale = 0f;
                    objectivesMenu.SetActive(true);
                    ObjectivesComplete.occurence.SetObj3Done(true);
                    completeObject3 = true;
                }
            }else if (Input.GetKeyDown(KeyCode.G))
            {
                player.transform.position = vehicleDoor.transform.position;
                isOpened = false;
                radius = 5f;
            }
        }
        if(isOpened == true)
        {
            tpsCam.SetActive(false);
            tpsCanvas.SetActive(false);
            aimCam.SetActive(false);
            aimCanvas.SetActive(false);
            playerCharacter.SetActive(false);
            MoveVehicle();
            VehicleSteering();
            ApplyBreaks();
            HitZombies();
        }
        else if(isOpened == false)
        {
            tpsCam.SetActive(true);
            tpsCanvas.SetActive(true);
            aimCam.SetActive(true);
            aimCanvas.SetActive(true);
            playerCharacter.SetActive(true);
        }
        
    }

    void MoveVehicle()
    {

        frontRightCollider.motorTorque = presentAcceleration;
        frontLeftCollider.motorTorque = presentAcceleration;
        backLeftCollider.motorTorque = presentAcceleration;
        frontRightCollider.motorTorque = presentAcceleration;
        presentAcceleration = accelerationForce * -Input.GetAxis("Vertical");
    }

    void VehicleSteering()
    {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontRightCollider.steerAngle = presentTurnAngle;
        frontLeftCollider.steerAngle = presentTurnAngle;
        SteeringWheels(frontRightCollider, frontRightTransform);
        SteeringWheels(frontLeftCollider, frontLeftTransform);
        SteeringWheels(backRightCollider, backRightTransform);
        SteeringWheels(backLeftCollider, backLeftTransform);

    }

    void SteeringWheels(WheelCollider wc, Transform wt)
    {
        Vector3 position;
        Quaternion rotation;
        wc.GetWorldPose(out position, out rotation);
        wt.position = position;
        wt.rotation = rotation;
    }

    void ApplyBreaks()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            presentBreakForce = breakingForce;
        }
        else
        {
            presentBreakForce = 0f;
        }
        frontRightCollider.brakeTorque = presentBreakForce;
        frontLeftCollider.brakeTorque = presentBreakForce;
        backRightCollider.brakeTorque = presentBreakForce;
        backLeftCollider.brakeTorque = presentBreakForce;

    }

    void HitZombies()
    {
        RaycastHit hitInfo;
        for (int i = 0; i < cam.Length; i++)
        {
            if (Physics.Raycast(cam[i].transform.position, cam[i].transform.forward, out hitInfo, hitRange))
            {
                Debug.Log(hitInfo.transform.name);
                Zombie1 zombie1 = hitInfo.transform.GetComponent<Zombie1>();
                Zombie2 zombie2 = hitInfo.transform.GetComponent<Zombie2>();
                ObjectToHit obj = hitInfo.transform.GetComponent<ObjectToHit>();

                if (zombie1 != null)
                {
                    zombie1.zombieHitDamage(giveDamageOf);
                    zombie1.GetComponent<CapsuleCollider>().enabled = false;
                    GameObject goreGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(goreGo, 1f);
                }
                else if (zombie2 != null)
                {
                    zombie2.zombieHitDamage(giveDamageOf);
                    zombie2.GetComponent<CapsuleCollider>().enabled = false;
                    GameObject goreGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(goreGo, 1f);
                }
                else if (obj != null)
                {
                    obj.ObjectHitDamage(giveDamageOf);
                    GameObject destroyGo = Instantiate(destroyEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(destroyGo, 1f);
                }
            }
        }

    }

    
}
