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

    // Novo booleano para controle de animação de ataque
    [SerializeField]
    private bool atacando;

    private void Start()
    {
        this.tempoEsperaProximoAtaque = this.intervaloEntreAtaques;
    }

    private void Update()
    {
        ProcurarJogador();
        if (this.alvo != null)
        {
            Mover();
            VerificarPossibilidadeAtaque();
        }
        else
        {
            PararMovimentacao();
        }

        // Atualiza o bool 'atacando' no Animator
        this.animator.SetBool("Atacando", this.atacando);
    }

    private void VerificarPossibilidadeAtaque()
    {
        if (this.alvo != null)
        {
            float distancia = Vector3.Distance(this.transform.position, this.alvo.position);
            if (distancia <= this.distanciaMaximaAtaque)
            {
                if (!this.atacando)
                {
                    this.tempoEsperaProximoAtaque -= Time.deltaTime;
                    if (this.tempoEsperaProximoAtaque <= 0)
                    {
                        this.tempoEsperaProximoAtaque = this.intervaloEntreAtaques;
                        IniciarAtaque();
                    }
                }
            }
            else
            {
                // Se estiver fora da distância de ataque, retorne para o estado "Andando"
                this.atacando = false;
            }
        }
    }

    private void IniciarAtaque()
    {
        this.atacando = true;
    }

    private void Atacar()
    {
        MiroHp miroHp = alvo.GetComponent<MiroHp>();
        miroHp.TakeDamage(0);

        // Reinicia o booleano para false após o ataque
        this.atacando = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
        if (this.alvo != null)
        {
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

            // Adiciona Debug.DrawRay para visualizar o raio no Editor
            Debug.Log("Direcao: " + direcao);
            Debug.DrawRay(posicaoAtual, direcao * this.raioVisao, Color.green);

            RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao);
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    this.alvo = hit.transform;
                    Debug.Log("Player Detectado");
                }
                else
                {
                    this.alvo = null;
                    Debug.Log("Outro Objeto Detectado");
                }
            }
            else
            {
                this.alvo = null;
                Debug.Log("Nenhum Objeto Encontrado na Direção do Inimigo");
            }
        }
        else
        {
            this.alvo = null;
            Debug.Log("Nenhum Colisor Encontrado na Área de Visão");
        }
    }

    private void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao);

            if (this.rigidbody.velocity.x > 0)
            {
                this.spriteRenderer.flipX = false;
            }
            else if (this.rigidbody.velocity.x < 0)
            {
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
