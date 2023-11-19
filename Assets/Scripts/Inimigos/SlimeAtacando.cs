using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAtacando : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    private int vida = 5;
    public float moveSpeed = 5f;

    public Transform player; // Referência para o jogador
    public float campoDeVisao; // Alcance de detecção
    public float campoDeAtaque; // Alcance de ataque

    public CircleCollider2D colliderAtk;
    public CircleCollider2D colliderCheckAtk;

    private bool isAttacking = false; // Flag para indicar se o inimigo está atualmente atacando

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador

        // Inicialize a posição inicial ou qualquer outra lógica de inicialização
    }

    void Update()
    {
        //UpdateSpriteAndColliders();

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > campoDeAtaque)
        {
            // Perseguir o jogador
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            //UpdateSpriteAndColliders(direction);

            // Verificar se o ataque deve ser iniciado
            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            // O inimigo não está no alcance de ataque, redefina a flag de ataque
            isAttacking = false;
        }

        if (vida == 0)
        {
            EnemyDead();
        }
    }

    //private void UpdateSpriteAndColliders()
    //{
    //    if (direction.x > 0)
    //    {
    //        sprite.flipX = false;
    //        UpdateCollidersOffsets(new Vector2(0.11f, 0.2f));
    //    }
    //    else if (direction.x < 0)
    //    {
    //        sprite.flipX = true;
    //        UpdateCollidersOffsets(new Vector2(-0.11f, -0.2f));
    //    }

    //    // Adicione aqui mais lógica para outras direções (cima, baixo, diagonal, etc.)
    //}

    //private void UpdateCollidersOffsets(Vector2 offset)
    //{
    //    colliderAtk.offset = offset;
    //    colliderCheckAtk.offset = offset;
    //}

    private void EnemyDead()
    {
        vida = 0;
        anim.SetTrigger("Dead");
        moveSpeed = 0;

        Destroy(transform.gameObject.GetComponent<CircleCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody>());
        Destroy(this.gameObject);
    }

    IEnumerator Attack()
    {
        isAttacking = true; // Defina a flag de ataque

        anim.SetBool("Ataque", true);
        moveSpeed = 0;

        yield return new WaitForSeconds(0.85f);

        // Lógica do ataque aqui

        anim.SetBool("Ataque", false);
        moveSpeed = 1;

        isAttacking = false; // Redefina a flag de ataque
    }


}
