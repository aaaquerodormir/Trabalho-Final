using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject painelDialogo;
    public Text textoDialogo;
    public string[] dialogo;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    //private bool teclaIPressionadaNoColisor;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && playerIsClose/* && !teclaIPressionadaNoColisor*/)
        {
            if(painelDialogo.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                painelDialogo.SetActive(true);
                StartCoroutine(Digitando());
                //teclaIPressionadaNoColisor = true;
            }
        }
        
        if(textoDialogo.text == dialogo[index])
        {
            contButton.SetActive(true);
        }

    }

    public void zeroText()
    {
        textoDialogo.text = "";
        index = 0;
        painelDialogo.SetActive(false);
        //teclaIPressionadaNoColisor = false;
    }

    IEnumerator Digitando()
    {
        foreach(char letter in dialogo[index].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void ProximaLinha()
    {

        contButton.SetActive(false);

        if(index < dialogo.Length - 1)
        {
            index++;
            textoDialogo.text = "";
            StartCoroutine(Digitando());
        }
        else
        {
            zeroText();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true; 
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
