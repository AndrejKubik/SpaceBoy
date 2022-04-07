using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private int randomIndex;
    public Transform ship;
    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Quaternion spawnRotation;

    [SerializeField] private bool gameIsActive;
    [SerializeField] private bool gameStarted;
    [SerializeField] private float spawnRate;

    #region Singleton

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private void Start()
    {
        gameIsActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //when player presses space key
        {
            SpawnObstacle(); //spawn an obstacle
        }

        if(gameStarted)
        {
            gameStarted = false;
            gameIsActive = true;
            StartCoroutine(SpawnObstacles(spawnRate));
        }
    }

    void SpawnObstacle()
    {
        spawnPoint = ship.position + spawnOffset; //calculate the position where the obstacle should spawn according to the chosen distance from the player
        float randomZ = Random.Range(0f, 360f); //get random Z-axis rotation
        spawnRotation = Quaternion.Euler(0, 0, randomZ); //calculate the random starting obstacle rotation


        randomIndex = Random.Range(0, obstacles.Length); //choose a random member of the obstacles array
        Instantiate(obstacles[randomIndex], spawnPoint, spawnRotation); //spawn a random obstacle at the calculated spawn position
    }

    IEnumerator SpawnObstacles(float spawnRate)
    {
        while(gameIsActive)
        {
            spawnPoint = ship.position + spawnOffset; //calculate the position where the obstacle should spawn according to the chosen distance from the player
            float randomZ = Random.Range(0f, 360f); //get random Z-axis rotation
            spawnRotation = Quaternion.Euler(0, 0, randomZ); //calculate the random starting obstacle rotation


            randomIndex = Random.Range(0, obstacles.Length); //choose a random member of the obstacles array
            Instantiate(obstacles[randomIndex], spawnPoint, spawnRotation); //spawn a random obstacle at the calculated spawn position

            yield return new WaitForSeconds(spawnRate); //wait for chosen ammount of seconds
        }
    }
}

