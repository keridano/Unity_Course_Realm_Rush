using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)][SerializeField] float frequency = 5f;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Text spawnedEnemy;

    int score = -1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        SetScore();
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SetScore();
            var instantiatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            instantiatedEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(frequency);
        }
    }

    private void SetScore()
    {
        score++;
        spawnedEnemy.text = $"Enemies\n{score}";
    }

    public void UpdateScoreWhenEnemyKilled()
    {
        score--;
        spawnedEnemy.text = $"Enemies\n{score}";
    }
}
