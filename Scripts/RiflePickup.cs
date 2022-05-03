using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    [Header("Rifle")]
    public GameObject rif;
    public GameObject playerRifle;
    public GameObject pickupRifle;

    public GameObject rifleUI;
    public GameObject objectivesMenu;

    [Header("Rifle Specs")]
    public PlayerScript player;
    private float radius = 2.5f;
    public Animator animator;



    private void Awake()
    {
        playerRifle.SetActive(false);
        rifleUI.SetActive(false);

    }

    private void Update()
    {   
       
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if (Input.GetKeyDown("f"))
            {
                rif.SetActive(true);
                playerRifle.SetActive(true);
                pickupRifle.SetActive(false);
                objectivesMenu.SetActive(true);
                Time.timeScale = 0f;
                ObjectivesComplete.occurence.SetObj1Done(true);
            }
        }
    }
}
