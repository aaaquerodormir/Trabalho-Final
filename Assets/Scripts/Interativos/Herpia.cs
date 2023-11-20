using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]

public class Herpia : MonoBehaviour
{
    public GameObject highlight;

    [SerializeField]
    private Miro _jogadorInterage;
    
    [SerializeField]
    private UnityEvent _botaoApertado;

    private bool _podeExecutar;

    

    // Update is called once per frame
    void Update()
    {
        if(_podeExecutar)
        {
            if (Miro.EstaInteragindo == true)
            {
                _botaoApertado.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _podeExecutar = true;

        if (collision.CompareTag("Player"))
        {
            highlight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _podeExecutar = false;

        if (collision.CompareTag("Player"))
        {
            highlight.SetActive(false);
        }
    }

    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }

    
}
