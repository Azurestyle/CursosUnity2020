using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;

    public float moveForce = 3;
    public GameObject focalPoint;
    public bool hasPowerUp;
    public float powerUpForce = 5f;

    public float powerUpTime = 7f;
    // Start is called before the first frame update
    
    public GameObject[] powerUpIndicators;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        //Es mejor utilizar en el futuro
        //focalPoint = GameObject.Find("Focal Point") y hacer la variable privada
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward*moveForce*forwardInput, ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = transform.position + 0.5f*Vector3.down;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
           
            StartCoroutine(PowerupCountdown());
        }

        if (other.gameObject.CompareTag("KillZone"))
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer*powerUpForce,ForceMode.Impulse);
            Debug.Log("ostion");
           
        }
    }

    IEnumerator PowerupCountdown()
    {
        
        foreach (GameObject indicator in powerUpIndicators)
        {
           indicator.gameObject.SetActive(true);
           yield return new WaitForSeconds(powerUpTime/powerUpIndicators.Length);
           indicator.gameObject.SetActive(false);
        }
        hasPowerUp = false;
    }
}
