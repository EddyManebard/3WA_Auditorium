using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private float _minVelocity = .02f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        if (_rb.velocity.magnitude < _minVelocity)
        {
            Destroy(gameObject);
        }
    }
}
