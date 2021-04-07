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
    [SerializeField] Button restartButton;

    void Start()
    {
        gameController.endGameEvent += ShowLosePanel;
        restartButton.onClick.AddListener(RestartButton);
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
    void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
