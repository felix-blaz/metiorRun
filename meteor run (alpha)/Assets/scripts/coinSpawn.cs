using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawn : MonoBehaviour
{
  

    private Rigidbody coinRb;
    private float zSpawnPos = -12;
    private float speed = 5.0f;
    private float xRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
       


        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < zSpawnPos && gameObject.CompareTag("coin"))
        {
            Destroy(gameObject);
            
        }
        
       else if (transform.position.z < zSpawnPos && gameObject.CompareTag("gcoin"))
        {
            Destroy(gameObject);

        }

       
        else if (transform.position.z < zSpawnPos && gameObject.CompareTag("scoin"))
        {
            Destroy(gameObject);

        }
    }

   

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), 0, Random.Range(10, 17));
    }
}
