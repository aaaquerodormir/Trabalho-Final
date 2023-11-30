using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMiro : MonoBehaviour
{
    public float novaGravidade = -5f;
    public int novaOrdemNaCamada = 1;


    private CanvasController _CanvasController;

    private void Start()
    {
        _CanvasController = FindObjectOfType(typeof(CanvasController)) as CanvasController;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {


            _CanvasController.GameOver();
            // Alterar a gravidade do player
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = novaGravidade;
            }

            // Mudar a ordem na camada do player
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = novaOrdemNaCamada;
            }
        }
    }
}
