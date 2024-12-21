using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _PlayingEnd();
    }

    private void _PlayingEnd()
    {
        if (_audioSource.isPlaying) return;
        Destroy(gameObject);
    }
}
