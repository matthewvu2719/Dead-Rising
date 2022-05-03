using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [Header("Camera to Assign")]
    public GameObject aimCam;
    public GameObject aimCanvas;
    public GameObject tpsCam;
    public GameObject tpsCanvas;

    [Header("Cam Animator")]
    public Animator animator;

    private void Update()
    {
        if (Input.GetButton("Fire2") && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IdleAim", true);
            animator.SetBool("Idle", false);
            animator.SetBool("RifleWalk", true);
            animator.SetBool("Walk", true);

            tpsCam.SetActive(false);
            tpsCanvas.SetActive(false);
            aimCam.SetActive(true);
            aimCanvas.SetActive(true);
        }
        else if(Input.GetButton("Fire2"))
        {
            animator.SetBool("IdleAim", true);
            animator.SetBool("Idle", false);
            animator.SetBool("RifleWalk", false);
            animator.SetBool("Walk", false);

            tpsCam.SetActive(false);
            tpsCanvas.SetActive(false);
            aimCam.SetActive(true);
            aimCanvas.SetActive(true);
        }
        else
        {
            animator.SetBool("IdleAim", false);
            animator.SetBool("Idle", true);
            animator.SetBool("RifleWalk", false);

            tpsCam.SetActive(true);
            tpsCanvas.SetActive(true);
            aimCam.SetActive(false);
            aimCanvas.SetActive(false);
        }
    }
}
