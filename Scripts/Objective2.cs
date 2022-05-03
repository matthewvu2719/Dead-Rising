using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective2 : MonoBehaviour
{
    public GameObject objectivesMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectivesMenu.SetActive(true);
            Time.timeScale = 0f;
            ObjectivesComplete.occurence.SetObj2Done(true);
            Destroy(gameObject, 2f);
        }
    }

   
}
