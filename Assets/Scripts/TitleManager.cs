using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField, Header("決定音")]
    private GameObject _submitSE;

    private bool _bStart;
    private Fade _fade;
    // Start is called before the first frame update
    void Start()
    {
        _bStart = false;
        _fade = FindObjectOfType<Fade>();
        _fade.FadeStart(_TitleStart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void _TitleStart()
    {
        _bStart = true;
    }

    private void _ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnSpaceClick(InputAction.CallbackContext context)
    {
        if (!context.performed && _bStart)
        {
            _fade.FadeStart(_ChangeScene);
            _bStart = false;
            Instantiate(_submitSE);
        }
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Application.Quit();
    }
}
