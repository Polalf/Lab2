using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    [SerializeField] float minCd, maxCd;
    float cd;
    public Transform[] spawns;
    public GameObject[] enemies;
   
    

    private void Start()
    {
       StartCoroutine(Spawnear());
    }

    IEnumerator Spawnear()
    {
        while(true)
        {
            int nSpawn = Random.Range(0, spawns.Length);
            int iEnemies = Random.Range(0, enemies.Length);
            Instantiate(enemies[iEnemies], spawns[nSpawn].transform.position, spawns[nSpawn].transform.rotation);
            cd = Random.Range(minCd, maxCd);
            yield return new WaitForSeconds(cd);
        }
        
    }
}
