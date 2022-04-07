using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFlight : MonoBehaviour
{
    [SerializeField] private Rigidbody obstacle;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 flightDirection;

    void Update()
    {
        obstacle.MovePosition(transform.position + flightDirection * speed * Time.deltaTime); //move the obstacle constantly towards the player

        if (transform.position.z <= (LevelManager.instance.ship.position.z - 50f))
        {
            Destroy(gameObject); //if the obstacle gets far enough behind the player, desttroy it
            Debug.Log("kurac");
        }
    }
}
