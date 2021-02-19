using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    private float repeatWidth;
    void Start()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - transform.position.x > repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
