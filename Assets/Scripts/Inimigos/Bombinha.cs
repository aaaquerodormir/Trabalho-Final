using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombinha : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private Rigidbody2D rigidbody;

     void Update()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {

            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao);
            Debug.Log("this.rigibody.velocity");
        }
        else
        {
            //Parar de mover
            this.rigidbody.velocity = Vector2.zero; // (0,0)
        }
    }
}
