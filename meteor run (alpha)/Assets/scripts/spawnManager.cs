using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    private Rigidbody meteorRb;
    //public GameObject meteorPrefab;
    //  private float startDelay = 2;
    // private float repeatRate = 2;
    
    private float minSpeed = 1;
    private float maxSpeed = 1;
    private float maxTorque = 10;
    private float xRange = 9;
    private float yRange = 15;
    private float xSpawnPos = -1;
    


    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnMeteor", startDelay, repeatRate);
        meteorRb = GetComponent<Rigidbody>();

        meteorRb.AddForce(RandomForce(), ForceMode.Impulse);
        meteorRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < xSpawnPos && gameObject.CompareTag("meteor"))
        {
            
            Destroy(gameObject);
            
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.down * Random.Range(minSpeed, maxSpeed);
    }

   float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), Random.Range(maxTorque, yRange), xSpawnPos);
    }

}
