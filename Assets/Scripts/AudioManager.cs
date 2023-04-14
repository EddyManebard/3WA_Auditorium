using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource[] _audioSources;
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
        for(int i = 0; i < _audioSources.Length; i ++)
        {
            if(_audioSources[i].volume == 1)
            {
                 Debug.Log("vous avez gagné!!!");
            }

        }

       /* while(AudioSource)
        {

        }*/
    }

}
