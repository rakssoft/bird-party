using UnityEngine;

public class SoundMAnger : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _enablemusic;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnMusic()
    {
        if (_enablemusic)
        {
            _enablemusic = false;
            _audioSource.Stop();
        }
        else
        {
            _enablemusic = true;
            _audioSource.Play();
        }
    }


}
