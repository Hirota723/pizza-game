using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _gameOverUI;
    [SerializeField, Header("ゲームクリアUI")]
    private GameObject _gameClearUI;
    [SerializeField, Header("BGM")]
    private AudioSource _bgm;
    [SerializeField, Header("決定音")]
    private GameObject _submitSE;
    [SerializeField, Header("ゲームクリアSE")]
    private GameObject _gameClearSE;
    [SerializeField, Header("ゲームオーバーSE")]
    private GameObject _gameOverSE;

    private GameObject _player;
    private bool _bShowUI;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _bShowUI = false;
        FindObjectOfType<Fade>().FadeStart(_MainStart);
        _player.GetComponent<Player>().enabled = false;
        _player.GetComponent<PlayerInput>().enabled = false;
        foreach (EnemySpawner enemySpawner in FindObjectsOfType<EnemySpawner>())
        {
            enemySpawner.enabled = false;
        }
    }

    private void _MainStart()
    {
        _player.GetComponent<Player>().enabled = true;
        _player.GetComponent<PlayerInput>().enabled = true;
        foreach (EnemySpawner enemySpawner in FindObjectsOfType<EnemySpawner>())
        {
            enemySpawner.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }

    private void _ShowGameOverUI()
    {
        if (_player != null || _gameOverUI.activeSelf) return;

        _gameOverUI.SetActive(true);
        _bShowUI = true;
        _bgm.Stop();
        Instantiate(_gameOverSE);
    }

    public void ShowGameClearUI()
    {
        if (_gameClearUI.activeSelf) return;

        _gameClearUI.SetActive(true);
        _bShowUI = true;
        _bgm.Stop();
        Instantiate(_gameClearSE);
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!_bShowUI || !context.performed) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Instantiate(_submitSE);
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Application.Quit();
    }
}
