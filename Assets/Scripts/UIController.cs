using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text scoreText;
    [SerializeField] Text coinText;
    [SerializeField] GameObject pausedText;
    [SerializeField] Button pauseButton;

    void Start()
    {
        gameController.endGameEvent += ShowLosePanel;
        pauseButton.onClick.AddListener(PauseButton);
        pausedText.SetActive(false);
    }

    void Update()
    {
        scoreText.text = Mathf.Round(gameController.score).ToString();
        coinText.text = gameController.coin.ToString();
    }

    void ShowLosePanel()
    {
        Instantiate(endGamePanel,gameObject.transform);
    }

    void PauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausedText.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausedText.SetActive(false);
        }
    }
}
