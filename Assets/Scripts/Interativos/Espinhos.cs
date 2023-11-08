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
       StartCoroutine(AlternarEstado());
    }

    // Update is called once per frame
    private IEnumerator AlternarEstado()
    {
        while (true)
        {
            yield return new WaitForSeconds(ativo ? tempoAtivado : tempoDesativado);

            ativo = !ativo;

            Collider2D[] colisores = GetComponentsInChildren<Collider2D>();
            foreach (Collider2D colisor in colisores)
            {
                colisor.enabled = ativo;
            }

            if (rend != null)
            {
                rend.material = ativo ? corAtivado : corDesativado;
            }
        }
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
