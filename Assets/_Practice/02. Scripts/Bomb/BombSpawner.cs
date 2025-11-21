using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;

    private float timer;
    public float spawnTime = 3f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            Vector3 randomPos = new Vector3(Random.Range(-25, 26), 10, Random.Range(-25, 26));
            Instantiate(bombPrefab, randomPos, Quaternion.identity);
        }
    }
}