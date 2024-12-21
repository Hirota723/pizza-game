using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fade : MonoBehaviour
{
    enum Mode
    {
        FadeIn,
        FadeOut
    }

    [SerializeField, Header("フェードの時間")]
    private float _fadeTime;
    [SerializeField, Header("フェードの種類")]
    private Mode _mode;

    private bool _bFade;
    private float _fadeCount;
    private Image _image;
    private UnityEvent _onFadeComplete = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        switch (_mode)
        {
            case Mode.FadeIn: _fadeCount = _fadeTime; break;
            case Mode.FadeOut: _fadeCount = 0; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _Fade();
    }

    private void _Fade()
    {
        if (!_bFade) return;

        switch (_mode)
        {
            case Mode.FadeIn: _FadeIn(); break;
            case Mode.FadeOut: _FadeOut(); break;
        }
        float alpha = _fadeCount / _fadeTime;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
    }

    private void _FadeIn()
    {
        _fadeCount -= Time.deltaTime;
        if (_fadeCount <= 0)
        {
            _mode = Mode.FadeOut;
            _bFade = false;
            _onFadeComplete.Invoke();
        }
    }

    private void _FadeOut()
    {
        _fadeCount += Time.deltaTime;
        if (_fadeCount >= _fadeTime)
        {
            _mode = Mode.FadeIn;
            _bFade = false;
            _onFadeComplete.Invoke();
        }
    }

    public void FadeStart(UnityAction listener)
    {
        if (_bFade) return;
        _bFade = true;
        _onFadeComplete.AddListener(listener);
    }
}
