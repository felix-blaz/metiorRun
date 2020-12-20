﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBack : MonoBehaviour
{
    private GameManager gameManager;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
