using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medo : MonoBehaviour
{
    private MeioCirculo meioCirculo;
    public LayerMask layerDoJogador;
    public float tempoEntreAtaques = 1f; // Alterado para atacar a cada 2 segundos
    private float timer;
    private Animator animator;
    private Collider2D currentPlayerCollider; // Adicionada uma variável para armazenar o collider do jogador atual

    void Start()
    {
        meioCirculo = GetComponent<MeioCirculo>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider2D playerCollider = DetectarJogador();

        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {
            if (EstaDentroDoMeioCirculo(playerCollider.transform.position))
            {
                // Verifica se o timer atingiu o tempo entre ataques
                if (timer >= tempoEntreAtaques)
                {
                    // Atualiza o collider do jogador atual
                    currentPlayerCollider = playerCollider;

                    // Atacar o jogador
                    AttackPlayer();
                    timer = 0f; // Reinicia o timer após o ataque
                }
                else
                {
                    // Incrementa o timer
                    timer += Time.deltaTime;


                }
                // Ativar a transição de idle para atacando
                animator.SetBool("Atacando", true);
            }
            else
            {
                // Resetar o timer se o jogador sair da área de visão
                ResetarTimer();

                animator.SetBool("Atacando", false);
            }
        }
        else
        {
            // Resetar o timer se o jogador não estiver na área de visão
            ResetarTimer();

            // Desativar a transição de atacando para idle
            animator.SetBool("Atacando", false);
        }
    }

    Collider2D DetectarJogador()
    {
        Collider2D[] resultados = Physics2D.OverlapCircleAll(transform.position, meioCirculo.raio, layerDoJogador);

        foreach (Collider2D resultado in resultados)
        {
            if (resultado.CompareTag("Player"))
            {
                return resultado;
            }
        }

        return null;
    }

    bool EstaDentroDoMeioCirculo(Vector3 position)
    {
        Vector3 offset = position - transform.position;
        float distanciaAoQuadrado = offset.x * offset.x + offset.y * offset.y;
        float raioAoQuadrado = meioCirculo.raio * meioCirculo.raio;

        return distanciaAoQuadrado <= raioAoQuadrado;
    }

    void AttackPlayer()
    {
        // Lógica de ataque ao jogador
        MiroHp playerHealth = currentPlayerCollider.GetComponent<MiroHp>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(2);
        }

        
    }

    void ResetarTimer()
    {
        timer = 0f;
    }
}
