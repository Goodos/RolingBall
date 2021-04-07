using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField] Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartButton);
    }

    void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
