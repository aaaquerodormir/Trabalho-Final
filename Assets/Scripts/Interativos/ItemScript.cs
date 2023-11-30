using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScript : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena para a qual você quer transicionar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player interagiu com o item, transiciona para a nova cena
            SceneManager.LoadScene("CenaFinal");
        }
    }
}
