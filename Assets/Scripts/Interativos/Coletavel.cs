using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public GameObject UIMensagem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Miro>().temColetavel = true;
            Destroy(this.gameObject);
        }

        if (UIMensagem != null)
        {
            UIMensagem.SetActive(true);
        }
    }
}
