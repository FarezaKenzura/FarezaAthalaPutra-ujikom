using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Properties")]
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private float rangeHorizontal = 5.0f;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private List<Animal> animals = new List<Animal>();

    private float currentSpawnInterval = 0.0f;
    
    private void Update() 
    {
        Spawning();
    }

    private void Spawning()
    {
        currentSpawnInterval += Time.deltaTime;

        if(currentSpawnInterval >= spawnInterval)
        {
            SpawnAnimal();
            currentSpawnInterval = 0.0f;
        }
    }

    private void SpawnAnimal()
    {
        Animal animal = animals[Random.Range(0, animals.Count)];
        Vector3 spawnPosition = spawnPlace.position + new Vector3(Random.Range(-rangeHorizontal, rangeHorizontal), 0, 0);
        Instantiate(animal, spawnPosition, animal.transform.rotation, spawnPlace);
    }

    private void OnDrawGizmos() 
    {
        if(!spawnPlace) return;

        Vector3 direction = new Vector3(rangeHorizontal, 0 ,0);
        Gizmos.DrawLine(spawnPlace.position - direction, spawnPlace.position + direction);    
    }
}
