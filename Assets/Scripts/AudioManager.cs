using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    private AudioSource[] _audioSources;
    private float _timeRemaining = 5f;

    [SerializeField]
    private bool _timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSources = GetComponentsInChildren<AudioSource>();

        foreach(AudioSource source in _audioSources)
        {
            source.Play();
        }
    }
    private void Update()
    {
       
        for(int i = 0; i < _audioSources.Length; i++)
        {
            if(_audioSources[i].volume == 1)
            {
                _timerIsRunning = true;
            }
            else
            {
                _timeRemaining = 5f;
                _timerIsRunning = false;
            }
        }
     
        if(_timerIsRunning)
        {
            StartTimer();
        }
        
       /* //FOREACH method
        if(!_timerIsRunning)
        {
            foreach(AudioSource source in _audioSources)
            {
                if(source.volume < 1)
                {
                    return;
                }
            }
            _timerIsRunning = true;
        }*/
      

    }


    private void StartTimer()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            Debug.Log(_timeRemaining);
        }
        else
        {
            Debug.Log("Vous avez gagné!!");
            _timeRemaining = 0;
            _timerIsRunning = false;
           
            //SceneManager.LoadScene("Level02");

        }
     
    }
}
