using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectivesComplete : MonoBehaviour
{
    [Header("Objectives")]
    public Text objective1;
    public Text objective2;
    public Text objective3;
    public Text objective4;

    public static ObjectivesComplete occurence;

    private void Awake()
    {
        occurence = this;
    }

    public void SetObj1Done(bool obj)
    {
        if (obj == true)
        {
            objective1.text = "01. Completed";
            objective1.color = Color.green;
        }
        else
        {
            objective1.text = "01. Find The Rifle";
            objective1.color = Color.white;
        }
    }


    public void SetObj2Done(bool obj) {

        if (obj == true)
        {
            objective2.text = "02. Completed";
            objective2.color = Color.green;
        }
        else
        {
            objective2.text = "02. Locate The Villagers";
            objective2.color = Color.white;
        }
    }

    public void SetObj3Done(bool obj) {
        if (obj == true)
        {
            objective3.text = "03. Completed";
            objective3.color = Color.green;
        }
        else
        {
            objective3.text = "03. Find The Vehicle";
            objective3.color = Color.white;
        }
    }

    public void SetObj4Done(bool obj) { 
        if (obj == true)
        {
            objective4.text = "04. Mission Completed";
            objective4.color = Color.green;
        }
        else
        {
            objective4.text = "04. Get All Villagers into vehicle";
            objective4.color = Color.white;
        }
    }
}
