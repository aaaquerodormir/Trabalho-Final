using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SiddingGame : MonoBehaviour
{
    [SerializeField] GameObject minigame;
    GameObject highlight;
    [SerializeField] GameObject targetObject;
    [SerializeField] LayerMask OtherSide;

    private bool isMinigameOpen = false;
    private bool isMouseOverMinigame = false;

    private void OnEnable()
    {
        highlight = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            highlight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            highlight.SetActive(false);
        }
    }

    public void PlayMiniGame()
    {
        minigame.SetActive(true);
        isMinigameOpen = true;
    }

    public void CloseMiniGame()
    {
        minigame.SetActive(false);
        isMinigameOpen = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, OtherSide);

            if (hit.collider != null)
            {
                if (hit.collider == targetObject.GetComponent<Collider2D>())
                {
                    if (!isMinigameOpen)
                    {
                        PlayMiniGame();
                    }
                }
                // Adicione verificação para ver se o mouse está sobre o minigame.
                else if (hit.collider == minigame.GetComponent<Collider2D>())
                {
                    isMouseOverMinigame = true;
                }
            }
            else
            {
                if (isMinigameOpen && !isMouseOverMinigame)
                {
                    CloseMiniGame();
                }
                // Redefina a variável isMouseOverMinigame.
                isMouseOverMinigame = false;
            }
        }
    }
}


