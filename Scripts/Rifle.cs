using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;

    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 15f;
    private float nextTimeToShoot = 0f;
    public Animator animator;
    public PlayerScript player;
    public Transform hand;
    public GameObject rifleUI;
    public PlayerPunch playerPunch;
    private float nextTimeToPunch = 0f;
    public float punchCharge = 15f;
    public GameObject rif;
    public GameObject akm;


    [Header("Rifle Ammo and Shooting")]
    private int maxAmmo = 32;
    public int mag = 10;
    private int presentAmmo;
    public float reloadingTime = 3f;
    private bool setReloading = false;
    public GameObject ammoOut;
    public AudioClip shootingSound;
    public AudioClip reloadingSound;
    public AudioSource audioSource;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject woodenEffect;
    public GameObject goreEffect;

    private void Awake()
    {
        transform.SetParent(hand);
        rifleUI.SetActive(true);
        presentAmmo = maxAmmo;
    }
    private void Update()
    {
        if(setReloading){
            return;
        }

        if(presentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        ChangeWeapon();
        if (rif.activeInHierarchy && akm.activeInHierarchy)
        {
            Gun();
        }
        else
        {
            Punch();
        }
        

    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown("1"))
        {
            akm.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            akm.SetActive(false);
        }
    }

    private void Punch()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToPunch)
        {
            animator.SetBool("Punch", true);
            animator.SetBool("Idle", false);
            nextTimeToPunch = Time.time + 1f / punchCharge;
            playerPunch.Punch();
        }
        else
        {
            animator.SetBool("Punch", false);
            animator.SetBool("Idle", true);
        }
    }

    private void Gun()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
            nextTimeToShoot = Time.time + 1f / fireCharge;
            Shoot();

        }
        else if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FireWalk", true);
            animator.SetBool("Idle", false);
        }
        else if (Input.GetButton("Fire1") && Input.GetButton("Fire2"))
        {
            animator.SetBool("IdleAim", true);
            animator.SetBool("Idle", false);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reload", false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
        }
    }
    private void Shoot()
    {   
        //check for mag
        if(mag == 0)
        {
            //show ammo out text
            StartCoroutine(AmmoOut());
            return;
        }

        presentAmmo--;
        if(presentAmmo == 0)
        {
            mag--;
        }

        //update the UI
        AmmoCount.occurrence.UpdateAmmoText(presentAmmo);
        AmmoCount.occurrence.UpdateMagText(mag);


        muzzleSpark.Play();
        audioSource.PlayOneShot(shootingSound);
        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
            Debug.Log(hitInfo.transform.name);
            ObjectToHit objectToHit = hitInfo.transform.GetComponent<ObjectToHit>();
            Zombie1 zombie1 = hitInfo.transform.GetComponent<Zombie1>();
            Zombie2 zombie2 = hitInfo.transform.GetComponent<Zombie2>();


            if (objectToHit != null)
            {
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject woodGo = Instantiate(woodenEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(woodGo, 1f);
            }
            else if(zombie1 != null)
            {
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreGo, 1f);
            }
            else if (zombie2 != null)
            {
                zombie2.zombieHitDamage(giveDamageOf);
                GameObject goreGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreGo, 1f);
            }
        }
    }

    IEnumerator Reload()
    {
        player.playerSpeed = 0f;
        player.playerSprint = 0f;
        setReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reload", true);
        audioSource.PlayOneShot(reloadingSound);
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("Reload", false);
        presentAmmo = maxAmmo;
        player.playerSpeed = 1.9f;
        player.playerSprint = 3f;
        setReloading = false;
    }

    IEnumerator AmmoOut()
    {
        ammoOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        ammoOut.SetActive(false);
    }
}
