using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidbody;

    private float minForce = 12,
        maxForce = 16,
        maxTorque = 10,
        xRange = 4,
        ySpawnPos = -6;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    /// <summary>
    /// Genera un vector aleatorio en 30
    /// </summary>
    /// <returns>Fuerza aleatoria para arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    /// <summary>
    /// Genera número aleatorio
    /// </summary>
    /// <returns>Valor aleatorio entre -maxTorque y maxTorque</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    /// <summary>
    /// Genera posición aleatoria
    /// </summary>
    /// <returns>Devuelve posición aleatoria en 3d, con la coordenada z =0</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
