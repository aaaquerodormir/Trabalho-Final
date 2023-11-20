using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguindo : MonoBehaviour
{
    public float speed;
    public float campoDeVisao;
    public float campoDeAtaque;

    private Rigidbody2D rb;
    public Animator anim;

    private Vector2 movEnemy;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        movEnemy = transform.position;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > campoDeAtaque)
        {
            movEnemy = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
            anim.SetFloat("Lateral", movEnemy.x);           // aqui temos o controle do animator para cada lado  
            anim.SetFloat("Vertical", movEnemy.y);
            anim.SetFloat("Speed", movEnemy.magnitude);
            movEnemy.Normalize();

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, campoDeVisao);
        Gizmos.DrawWireSphere(transform.position, campoDeAtaque);
    }
}