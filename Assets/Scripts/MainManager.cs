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

    private GameObject _player;
    private bool _bShowUI;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _bShowUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }

    private void _ShowGameOverUI()
    {
        if (_player != null) return;

        _gameOverUI.SetActive(true);
        _bShowUI = true;
    }

    public void ShowGameClearUI()
    {
        _gameClearUI.SetActive(true);
        _bShowUI = true;
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!_bShowUI || !context.performed) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
