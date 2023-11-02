using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiroEmpurrar : MonoBehaviour
{
    public float forcaEmpurrar = 2f;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ObjetoEmpurravel"))
            {
                ObjetoEmpurravel objetoEmpurravel = collision.gameObject.GetComponent<ObjetoEmpurravel>();
                float movimentoHorizontal = Input.GetAxis("Horizontal");
                objetoEmpurravel.Empurrar(Vector2.right * movimentoHorizontal * forcaEmpurrar);
            }
        }
    
}
