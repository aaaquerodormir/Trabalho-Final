using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSlime : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    #region movimentação


    [SerializeField]
    private float velocidadeMovimento;
    [SerializeField]
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private float distanciaMinima;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    #endregion
    #region Visão
    [SerializeField]
    private Color corAreaVisao;
    [SerializeField]
    private Color corDirecaoMovimento;
    [SerializeField]
    private float raioVisao;
    [SerializeField]
    private LayerMask layerAreaVisao;
    #endregion

    [SerializeField]
    private float distanciaMaximaAtaque;
    [SerializeField]
    private float intervaloEntreAtaques;
    private float tempoEsperaProximoAtaque;


    private void Start()
    {
        this.tempoEsperaProximoAtaque = this.intervaloEntreAtaques;
    }
    private void Update()
    {
        ProcurarJogador();
        if(this.alvo != null)
        {
            Mover();
            VerificarPossibilidadeAtaque();
        }
        else
        {
            PararMovimentacao();
        }
    }
    private void VerificarPossibilidadeAtaque()
    {
        float distancia = Vector3.Distance(this.transform.position, this.alvo.position);
        if (distancia <= this.distanciaMaximaAtaque)
        {
            this.tempoEsperaProximoAtaque -= Time.deltaTime;
            if(this.tempoEsperaProximoAtaque <= 0) {
                this.tempoEsperaProximoAtaque = this.intervaloEntreAtaques;
                Atacar();
            }
        }
    }

    private void Atacar()
    {
        this.animator.SetTrigger("atacando");
        MiroHp miroHp = alvo.GetComponent<MiroHp>();
        miroHp.TakeDamage(0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        if(this.alvo != null) {
            Gizmos.DrawLine(this.transform.position, this.alvo.position); 
        }
    }

    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if (colisor != null)
        {
            Vector2 posicaoAtual = this.transform.position;
            Vector2 posicaoAlvo = colisor.transform.position;
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao);
            if (hit.transform != null) //Encontrou obj
            { if (hit.transform.CompareTag("Player")) { // Obj possui a tag jogador
                    // define o jogador como alvo
                    this.alvo = hit.transform;
               }
                else{ //Encontrou outro obj q nn é o jogador
                    //Jogador dentro da area de visao,
                    //mas nao pode ser visto,
                    //Existe algo entre eles.
                    this.alvo = null;
                }

            }
            else {// Nenhum obj encontrado na direcao do inimigo
                this.alvo = null;
            }
        } else{
            this.alvo = null;
        }
    }

    private void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if(distancia >= this.distanciaMinima)
        {
            //mover o inimigo
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao);
            
            if(this.rigidbody.velocity.x > 0)
            {
                this.spriteRenderer.flipX = false;
            } else if (this.rigidbody.velocity.x < 0) { 
                this.spriteRenderer.flipX = true;
            }
            this.animator.SetBool("movendo", true);
        }
        else
        {
            PararMovimentacao();
        }
    }

    private void PararMovimentacao()
    {
        this.rigidbody.velocity = Vector2.zero;
        this.animator.SetBool("movendo", false);
    }
}
