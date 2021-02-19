using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;

    private float lowerBound = -20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.z < lowerBound )
        {   
            Debug.Log("GAME OVER!");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
