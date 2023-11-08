using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public float tempoAtivado = 3f;
    public float tempoDesativado = 3f;
    public Material corAtivado;
    public Material corDesativado;

    private bool ativo = true;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Invoke("AlternarEstado", tempoAtivado);
    }

    // Update is called once per frame
    private void AlternarEstado()
    {
        ativo = !ativo;

        Collider2D[] colisores = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D colisor in colisores)
        {
            colisor.enabled = ativo;
        }
        if (rend != null)
        {
            if (ativo)
            {
                rend.material = corAtivado;
            }
            else
            {
                rend.material = corDesativado;
            }
        }
        float proximoTempo = ativo ? tempoAtivado : tempoDesativado;
        Invoke("AlternarEstado", proximoTempo);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ativo)
        {
            MiroHp playerHealth = other.gameObject.GetComponent<MiroHp>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(4);
            }
        }
       
    }

    //private void Update()
    //{
    //    if (tempoAtivado >= tempoDesativado)
    //    {
            
    //        tempoAtivado = 0; // Reseta o timer.
    //    }
    //}
}
