using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwner : MonoBehaviour
{
    public GameObject item;
    public float timeToSpawn = 2f;
    public float spawnDelay = 15f;
    public static bool stopSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", timeToSpawn, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawnObject()
    {
        Instantiate(item,transform.position,Quaternion.identity);
        if (stopSpawn)
        {
            CancelInvoke("spawnObject");
        }
    }
}
