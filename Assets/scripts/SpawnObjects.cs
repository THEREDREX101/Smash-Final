using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{

    public GameObject[] enemies;


    public float timeSpawm = 1;

    public float repeatSpawnRate = 1;


    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawm, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {

        Vector3 spawnPosition = new Vector3(0, 0, 0);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x,xRangeRight.position.x), Random.Range(yRangeDown.position.y,yRangeUp.position.y),0);

        GameObject enemie = Instantiate(enemies[0], spawnPosition,gameObject.transform.rotation);

    }
}
