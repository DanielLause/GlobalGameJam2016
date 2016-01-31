using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawn : MonoBehaviour
{
<<<<<<< HEAD
    public bool PlacedItems = true;
    public List<GameObject> Items;
    public List<Transform> SpawnPoints;
    public Spawner spawner;
=======

    public List<GameObject> Items;
    public List<Transform> SpawnPoints;

>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
    private List<Transform> constSpawnPoints;
    private List<Transform> alreadyInUse;
    int chosedItem;
    int chosedSpawn;

<<<<<<< HEAD

=======
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
    void Awake()
    {
        constSpawnPoints = SpawnPoints;
        alreadyInUse = new List<Transform>();
    }

    void Update()
    {
<<<<<<< HEAD
        if (PlacedItems)
        {
            PlacedItems = false;
            randomSpawn();
            resetList();
=======
        if (Input.GetKeyDown("l"))
        {
            randomSpawn();
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
        }
    }

    private void resetList()
    {
        SpawnPoints = constSpawnPoints;
        alreadyInUse.Clear();
    }
    private void randomSpawn()
    {
<<<<<<< HEAD
        for (int i = 0; i <= spawner.CurrentWave.Number-1; i++)
        {
            if (SpawnPoints.Count == 0)
                return;

            chosedSpawn = Random.Range(0, SpawnPoints.Count);
            chosedItem = Random.Range(0, Items.Count);

            Instantiate(Items[chosedItem], SpawnPoints[chosedSpawn].position, Quaternion.identity);
            alreadyInUse.Add(SpawnPoints[chosedSpawn]);
            SpawnPoints.Remove(SpawnPoints[chosedSpawn]);
        }
=======
        if (SpawnPoints.Count == 0)
            return;

        chosedSpawn = Random.Range(0, SpawnPoints.Count);
        chosedItem = Random.Range(0, Items.Count);

        Instantiate(Items[chosedItem], SpawnPoints[chosedSpawn].position, Quaternion.identity);
        alreadyInUse.Add(SpawnPoints[chosedSpawn]);
        SpawnPoints.Remove(SpawnPoints[chosedSpawn]);
>>>>>>> e8ee4ce1d78ad2fe17179b1d3b24547f83da7abc
    }
}
