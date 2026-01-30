using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;

    public float spawnInterval = 1.5f;

    public float xRange = 8f;

    void Start()
    {
        // Belirlenen aralýklarla "SpawnItem" fonksiyonunu çaðýrýr
        InvokeRepeating("SpawnItem", 0f, spawnInterval);
    }

    void SpawnItem()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 6f, 0f);

        int randomIndex = Random.Range(0, itemPrefabs.Length);

        Instantiate(itemPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}