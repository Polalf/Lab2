using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public CharactersStats playerStats;
    [SerializeField] KeyCode atk;
    bool canAtk;
    void Start()
    {
        Time.timeScale = 1;
        canAtk =true;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x,y).normalized * playerStats.speed * Time.deltaTime;

        if(Input.GetKey(atk))
        {
            if(canAtk)
            {
                foreach (Transform shoter in playerStats.shootCtrl)
                {
                    canAtk = false;
                    Instantiate(playerStats.bullet, shoter.position, shoter.rotation);
                }
                StartCoroutine(Disparo());
            }
        }
    }

    IEnumerator Disparo()
    {
         
        yield return new WaitForSeconds(playerStats.cd);
        canAtk = true;
    }
}
