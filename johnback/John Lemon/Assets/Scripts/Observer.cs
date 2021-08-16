using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;
    private bool isPlayerInRange;
    public GameEnding gameEnding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            RaycastHit raycastHit;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.green, Time.deltaTime);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CatchPlayer();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.DrawLine(transform.position, player.position + Vector3.up);
    }
}
