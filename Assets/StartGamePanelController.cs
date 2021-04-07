using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamePanelController : MonoBehaviour
{
    [SerializeField] Button startGameButton;
    [SerializeField] GameController gameController;

    void Start()
    {
        startGameButton.onClick.AddListener(StartGameButton);
    }

    void StartGameButton()
    {
        gameController.canMove = true;
        Destroy(gameObject);
    }
}
