using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SlitSpawner _spawner;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _gameOverScreen;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _player.OnPlayerDie += GameOver;
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _spawner.ResetPool();
        _player.ResetGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
    }
}
