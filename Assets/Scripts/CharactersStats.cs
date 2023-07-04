using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharactersStats : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] int Maxlife;
    int currentLife;
    [SerializeField] SpriteRenderer sr;
    Collider2D cCollider;
    public UnityEvent onDeath;
    public string[] tagDamage; 

    [Header("Movement")]
    public float speed;

    [Header("Attack")]
    public float cd;
    public GameObject bullet;
    public Transform[] shootCtrl;

    private void Start()
    {
        currentLife = Maxlife;
        cCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(currentLife <= 0)
        {
            Muelto();

        }
    }
    //funciones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string tag in tagDamage)
        { 
            if(collision.gameObject.CompareTag(tag))
            {
                TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
            }
        }
    }
    public void TakeDamage(int _Damage)
    {
        currentLife-= _Damage;
        StartCoroutine(TakingDmgAnim());
    }

    private void Muelto()
    {
        onDeath.Invoke();

    }

    //Coroutinas
    IEnumerator TakingDmgAnim()
    {
        bool act = false;
        cCollider.enabled = false;
        for(int i = 0; i < 4; i++)
        {
            act = !act;
            sr.enabled = act;
            yield return new WaitForSeconds(0.1f);
        }
        cCollider.enabled = true;
        sr.enabled = true;
    }
}
