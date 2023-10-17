using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _valortransp = 0.7f;
    [SerializeField] private float _fadetime = 0.4f;

    private SpriteRenderer _spriterenderer;


    void Awake()
    {
     _spriterenderer = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Miro>())
        {
            StartCoroutine(FadeTree(_spriterenderer, _fadetime, _spriterenderer.color.a, _valortransp));

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Miro>())
        {
            StartCoroutine(FadeTree(_spriterenderer, _fadetime, _spriterenderer.color.a, 1f));

        }

    }





    private IEnumerator FadeTree(SpriteRenderer _spriteTransparency, float _fadeTime, float _startValue, float targetTransparency)
    {
        float _timeElapsed = 0;
        while(_timeElapsed < _fadeTime) {
        
            _timeElapsed += Time.deltaTime; 
            float _newAlpha = Mathf.Lerp(_startValue, targetTransparency, _timeElapsed /  _fadeTime);

            _spriteTransparency.color = new Color(_spriteTransparency.color.r, _spriteTransparency.color.g, _spriteTransparency.color.b, _newAlpha);

            yield return null;
        }


        


    }
}
