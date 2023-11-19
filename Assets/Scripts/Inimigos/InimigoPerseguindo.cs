using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguindo : MonoBehaviour
{
    public float speed;
    public float campoDeVisao;
    public float campoDeAtaque;



    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > campoDeAtaque)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, campoDeVisao);
        Gizmos.DrawWireSphere(transform.position, campoDeAtaque);
    }
}