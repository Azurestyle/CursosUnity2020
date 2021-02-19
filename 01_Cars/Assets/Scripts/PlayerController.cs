using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Range(0,20), SerializeField, 
     Tooltip("Velocidad lineal máxima del coche")]
    public float speed = 20.0f;
    
    [Range(0,25), SerializeField,
     Tooltip("Velocidad de giro máxima del coche")]
    private float turnSpeed = 50f;
    
    private float horizontalInput, verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // s = s0 + v*t*direction
        transform.Translate(speed*Time.deltaTime*Vector3.forward * verticalInput); // 0,0,1
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
        
        
        
    }
}
