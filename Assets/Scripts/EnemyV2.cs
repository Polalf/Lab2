using System.Collections;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    public CharactersStats enemyStats;
    public float activarY;
    public int puntaje;
    bool canAct;
    void Start()
    {

        canAct = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.up * enemyStats.speed * Time.deltaTime;
        if (canAct)
        {
            if (transform.position.y < activarY)
            {
                StartCoroutine(DisparoEnemy());
                canAct = false;
            }
        }
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }

    public void Morir()
    {
        Player.instance.gameObject.GetComponent<ScoreControl>().score += puntaje;
        Destroy(gameObject);
    }

    IEnumerator DisparoEnemy()
    {
        while (true)
        {
            foreach (Transform shoter in enemyStats.shootCtrl)
            {
                Instantiate(enemyStats.bullet, shoter.position, shoter.rotation);
               
            }
            yield return new WaitForSeconds(enemyStats.cd);
        }


    }
}
