using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject zombiePrefab1;
    public GameObject zombiePrefab2;
    public GameObject zombiePrefab3;
    public GameObject zombiePrefab4;
    public GameObject zombiePrefab5;
    public GameObject zombiePrefab6;
    public Transform zombieSpawnPosition1;
    public Transform zombieSpawnPosition2;
    public Transform zombieSpawnPosition3;
    public Transform zombieSpawnPosition4;
    public Transform zombieSpawnPosition5;
    public Transform zombieSpawnPosition6;


    private void Awake() 
    { 
        for(int i = 0; i < 20; i++)
        {
            Instantiate(zombiePrefab1, zombieSpawnPosition1.position, zombieSpawnPosition1.rotation);
            Instantiate(zombiePrefab2, zombieSpawnPosition2.position, zombieSpawnPosition2.rotation);
            Instantiate(zombiePrefab3, zombieSpawnPosition3.position, zombieSpawnPosition3.rotation);
            Instantiate(zombiePrefab4, zombieSpawnPosition4.position, zombieSpawnPosition4.rotation);
            Instantiate(zombiePrefab5, zombieSpawnPosition5.position, zombieSpawnPosition5.rotation);
            Instantiate(zombiePrefab6, zombieSpawnPosition6.position, zombieSpawnPosition6.rotation);

        }
    }


}
