using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBolder : MonoBehaviour
{
    private Rigidbody bolderRb;
    private float zSpawnPos = -6;
    private float speed = 15.0f;
    private GameManager gameManager;
    public GameObject bolderPrefab;
    private float startDelay = 15;
    private float repeatDelay = 10;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnPowerup", startDelay, repeatDelay);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bolderRb = GetComponent<Rigidbody>();
        bolderRb.AddTorque(1, 0, -5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < zSpawnPos && gameObject.CompareTag("Bolder"))
        {
            Destroy(gameObject);
        }
    }
    void SpawnPowerup()
    {
        if (gameManager.isGameActive)
        {
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 1, 20);
            Instantiate(bolderPrefab, position, bolderPrefab.transform.rotation);
        }
    }
}