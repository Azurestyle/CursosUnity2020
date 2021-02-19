using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float translateSpeed = 10;
    public float rotateSpeed = 180;
    // Update is called once per frame
    void Update()
    {   
       // transform.Translate(Vector3.right*Time.deltaTime*translateSpeed);
        transform.localPosition += Vector3.left * translateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up*Time.deltaTime*rotateSpeed);
    }
}
