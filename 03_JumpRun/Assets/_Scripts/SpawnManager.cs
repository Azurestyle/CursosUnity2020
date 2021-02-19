using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    // Start is called before the first frame update
    private Vector3 spawnPos;
    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController _playerController;
    void Start()
    {
        spawnPos = this.transform.position; //30,0,0
        InvokeRepeating("SpawnObstacle", startDelay,
            repeatRate);

        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, 
                obstaclePrefab.transform.rotation);
        }
       
    }
}
