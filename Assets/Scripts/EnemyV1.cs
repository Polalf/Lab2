using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV1 : MonoBehaviour
{
    public CharactersStats enemyStats;
    
    float currentSpeed;
    public float chaseRadio, atkRadio;
    //public Transform[] pointPatrol;
    [SerializeField]Transform target;
    [SerializeField] bool onPatrol;
    void Start()
    {
        currentSpeed = enemyStats.speed;
        onPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, Player.instance.transform.position);

        transform.position += transform.up * enemyStats.speed * Time.deltaTime;

        if(dis < chaseRadio)
            onPatrol = false;
        if (onPatrol)
        {
            float rad = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x);
            transform.localEulerAngles = new Vector3(0, 0, (rad * Mathf.Rad2Deg) - 90);
        }
        else
        {
            float rad = Mathf.Atan2(Player.instance.transform.position.y - transform.position.y, Player.instance.transform.position.x - transform.position.x);
            transform.localEulerAngles = new Vector3(0, 0, (rad * Mathf.Rad2Deg) - 90);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadio);

    }
    private void OnDrawGizmosSelected()
    {
        
    }

}
