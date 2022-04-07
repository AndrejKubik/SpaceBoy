using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Kurac");
            Destroy(other.gameObject);
        }
    }
}
