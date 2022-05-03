using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    [Header("HealthBoost")]
    public PlayerScript player;
    private float healthToGive = 120f;
    private float radius = 2.5f;
    public HealthBar healthBar;

    [Header("Sounds")]
    public AudioClip healthSound;
    public AudioSource audioSource;

    [Header("Animator")]
    public Animator animator;

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)< radius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetBool("Open", true);
                player.presentHealth = healthToGive;
                healthBar.SetHealth(healthToGive);
                audioSource.PlayOneShot(healthSound);

                Object.Destroy(gameObject, 1.5f);
            }
        }
    }
}
