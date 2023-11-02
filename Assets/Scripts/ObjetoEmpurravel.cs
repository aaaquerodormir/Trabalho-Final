using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEmpurravel : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Empurrar(Vector2 forca)
    {
        rb.AddForce(forca);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Botao"))
        {
            GameObject porta = GameObject.FindGameObjectWithTag("Porta");
            if (porta != null)
            {
                porta.SetActive(false); // Desativa a porta
            }
        }
    }
}
