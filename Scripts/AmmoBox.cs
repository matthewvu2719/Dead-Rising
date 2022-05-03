using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [Header("AmmoBoost")]
    public Rifle rifle;
    private int magToGive = 15;
    private float radius = 2.5f;
    public AmmoCount ammoCount;

    [Header("Sounds")]
    public AudioClip ammoSound;
    public AudioSource audioSource;

    [Header("Animator")]
    public Animator animator;

    private void Update()
    {
        if (Vector3.Distance(transform.position, rifle.transform.position) < radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Open", true);
                rifle.mag = magToGive;
                ammoCount.magText.text =  "Magazines. " + magToGive;
                audioSource.PlayOneShot(ammoSound);

                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
