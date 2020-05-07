using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject foodToSpawn = null;

    [SerializeField] Transform spawnLocation = null;

    public void SpawnFood()
    {
        Instantiate(foodToSpawn, spawnLocation.position, spawnLocation.rotation);
    }
}
