using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)][SerializeField] float frequency = 5f;
    [SerializeField] Enemy enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            instantiatedEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(frequency);
        }
    }
}
