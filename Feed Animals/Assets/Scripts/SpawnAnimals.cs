using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    public GameObject[] animals;
    
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 1.5f, 1f);
    }

    private void SpawnAnimal()
    {
        int randomAnimalIndex = Random.Range(0, animals.Length);
        Vector3 randomPosition = new Vector3(Random.Range(-26, 26), 0, 25);

        Instantiate(animals[randomAnimalIndex], randomPosition, animals[randomAnimalIndex].transform.rotation);
    }
}
