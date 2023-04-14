using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    Renderer[] _volumeBarsRenderer;
    [SerializeField]
    private Material _volumeBarOffMaterial;
    [SerializeField]
    private Material _volumeBarOnMaterial;
    [SerializeField]
    private float _delayWihoutParticle;
    [SerializeField]
    private float _volumeSpeed;
    [SerializeField]
    private float _particleVolumeIncrease;

    private float _lastParticleCollisionTime;

    private void Start()
    {
       // _audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > _lastParticleCollisionTime + _delayWihoutParticle)
        {
            _audioSource.volume -= _volumeSpeed * Time.deltaTime;
        }
        float volume = _audioSource.volume;

        for(int i=0; i <_volumeBarsRenderer.Length; i++)
            {
            float vol = i + 1f;

                if(volume >= vol * 1 / _volumeBarsRenderer.Length)
                     {
                _volumeBarsRenderer[i].material = _volumeBarOnMaterial;

                     }
                else
                    {
                _volumeBarsRenderer[i].material = _volumeBarOffMaterial; 
                    }
            }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Particle"))
        {
            if(_audioSource.volume < 1)
            {
            _audioSource.volume += _particleVolumeIncrease ;

            }
            _lastParticleCollisionTime = Time.time;

            Debug.Log("Particle collided");
        }
    }

}
