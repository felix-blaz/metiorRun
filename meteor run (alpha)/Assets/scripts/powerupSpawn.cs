using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpawn : MonoBehaviour
{
    private float zSpawnPos = -6;
    private float speed = 10.0f;
    private GameManager gameManager;
    public GameObject powerupPrefab;
    private float startDelay  = 3;
    private float repeatDelay  = 8;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", startDelay, repeatDelay);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < zSpawnPos && gameObject.CompareTag("Powerup"))
        {
            Destroy(gameObject);
        }
    }
    void SpawnPowerup()
    {
        if (gameManager.isGameActive)
        {
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(10, 17));
            Instantiate(powerupPrefab, position, powerupPrefab.transform.rotation);
        }
    }
}
