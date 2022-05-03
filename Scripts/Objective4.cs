using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective4 : MonoBehaviour
{
    public GameObject objectivesMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            objectivesMenu.SetActive(true);
            Time.timeScale = 0f;
            ObjectivesComplete.occurence.SetObj4Done(true);

        }
    }

    IEnumerator MissionComplete()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }


}
