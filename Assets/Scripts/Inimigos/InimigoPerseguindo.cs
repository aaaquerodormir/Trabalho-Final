using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguindo : MonoBehaviour
{
    public float velocidade = 2f; // velocidade do inimigo
    public float distanciaDePerseguicao = 5f; // distância para o inimigo começar a perseguir
    private Transform jogador;
    private Rigidbody2D rb;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Vê certinho a distância para o player
        float distanciaParaJogadorX = Mathf.Abs(transform.position.x - jogador.position.x);
        float distanciaParaJogadorY = Mathf.Abs(transform.position.y - jogador.position.y);

        // Se tiver dentro da distância necessária
        if (distanciaParaJogadorX < distanciaDePerseguicao && distanciaParaJogadorY < distanciaDePerseguicao)
        {
            // calcula a direção para o player no eixo X
            float direcaoX = (jogador.position.x - transform.position.x);
            float direcaoY = jogador.position.y - transform.position.y;

            // Normaliza as direções para manter a mesma velocidade em qualquer direção
            Vector2 direcaoNormalizada = new Vector2(direcaoX, direcaoY).normalized;

            // Move o inimigo apenas no eixo X
            rb.velocity = direcaoNormalizada * velocidade;
        }
        else
        {
            // Para o movimento se o jogador estiver fora da distância de perseguição
            rb.velocity = Vector2.zero;
        }
    }
}
