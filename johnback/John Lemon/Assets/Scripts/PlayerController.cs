using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;

    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float turnSpeed = 200f;

    //Para que no pete le asignamos un quaternion
    private Quaternion rotation = Quaternion.identity;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal,0,vertical);
        movement.Normalize();
        // Si hay moviemiento horizontal
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        // Si hay movimiento vertical
        // Aproximately te dice si vertical es aproximado a 0
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // Si se mueve horizontalmente o verticalmente significa que se está moviendo
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        _animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
        
        // Para movimientos smooth (lerp) interpolar entre dos puntos slerp esféricamente, moveTowards, rotateTowards
        // De donde estás mirando a donde quieres mirar
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed*Time.fixedDeltaTime, 0f);
        
        // Al hacer combinaciones de rotaciones y movmimentos con quaternions los hace bien
        rotation = Quaternion.LookRotation(desiredForward);
        
        //Rigidbody no tiene metodos de quaternion
        
    }

    private void OnAnimatorMove()
    {
         // Como la propia animacion ya aporta velocidad de movimiento, tenemos que hacer el * _animator.deltaPosition.magnitude
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(rotation);
    }
}
