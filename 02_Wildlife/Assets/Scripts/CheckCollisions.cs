using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // el animal choca contra un proyectil
            
            Destroy(this.gameObject); // destruye el animal
            Destroy(other.gameObject); //destruye lo otro
        }
        
    }
}
