using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerProt : MonoBehaviour
{   
    [Range(0,10)]
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    private float verticalInput, horizontalInput;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Si se utiliza la fisica
        // Addforce sobre el rigidbody
        //AddTorque sobre el rigidbody (equivalente a rotate)
        //_rigidbody.AddForce(Vector3.forward*speed*Time.deltaTime*verticalInput, ForceMode.Force);
       // _rigidbody.AddTorque(Vector3.up*speed*Time.deltaTime*horizontalInput, ForceMode.Force);
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime*verticalInput);
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime*horizontalInput);
        // Si no se utiliza la fisica, se usa metodo
        // Translate sobre transform -> para mover
        //Rotate sobre el transform -> para rotar

        if (Mathf.Abs(transform.position.x) >= 24 || Mathf.Abs(transform.position.z)>=24)
        {
            _rigidbody.velocity = Vector3.zero;
            
        }
    }
    
}
