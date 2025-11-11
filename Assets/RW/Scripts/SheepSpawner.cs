using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject sheepPrefab;
    public GameObject wolfPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns = 2f;
    public float wolfSpawnRate = 0.2f;

    private List<GameObject> sheepList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnAnimal()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject prefabToSpawn = (Random.value < wolfSpawnRate) ? wolfPrefab : sheepPrefab;
        GameObject animal = Instantiate(prefabToSpawn, randomPosition, prefabToSpawn.transform.rotation);
        sheepList.Add(animal);

        if (prefabToSpawn == sheepPrefab)
        {
            animal.GetComponent<Sheep>().SetSpawner(this);
        }
        else
        {
            animal.GetComponent<Wolf>().SetSpawner(this);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnAnimal();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }
        sheepList.Clear();
    }
}