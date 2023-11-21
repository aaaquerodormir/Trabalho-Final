using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InimigoSeguePlayer : MonoBehaviour
{
    public float speed;
    public float campoDeVisao;
    public float distanciaTiro;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;

    // barra de vida
    public Transform healthBar;
    public GameObject healthBarObject;

    private Vector3 healthBarScale;
    private float healthPercent;
    public float health;

    public int damage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x / health;
        damage = 5;
    }

    void UpdateHealthBar()
    {
        healthBarScale.x = healthPercent * health;
        healthBar.localScale = healthBarScale;
    }

    
    void Update()
    {
        /* float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
         if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > distanciaTiro)
         {
             transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
         }
         else if (distanceFromPlayer <= distanciaTiro && nextFireTime < Time.time)
         {
             Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
             nextFireTime = Time.time + fireRate;
         } */

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > distanciaTiro)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
        }
        else if (distanceFromPlayer <= distanciaTiro && nextFireTime < Time.time)
        {
            // Use a posição do inimigo como ponto de origem para a bala
            Instantiate(bullet, transform.position, Quaternion.identity);

            nextFireTime = Time.time + fireRate;
        }

        if (health < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, campoDeVisao);
        Gizmos.DrawWireSphere(transform.position, distanciaTiro);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CATK"))
        {
            health -= damage;
            UpdateHealthBar();
        }
    }

    
}
