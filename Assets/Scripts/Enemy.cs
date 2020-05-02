using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const float colliderSize = 7.5f;
    const float colliderCenter = 7.5f;

    [Header("Death & Collisions")]

#pragma warning disable 0649
    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
#pragma warning restore 0649

    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hits = 100;
    bool isDying;

    [Header("Movement")]
    [SerializeField] float frequency = 1f;
    List<Waypoint> path;

    void Start()
    {
        AddBoxCollider();
        SetupEnemyPath();
        StartCoroutine(FollowPath());
    }

    private void AddBoxCollider()
    {
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(0f, colliderCenter, 0f);
        boxCollider.size = new Vector3(colliderSize, colliderSize, colliderSize);
        boxCollider.isTrigger = false;
    }

    private void SetupEnemyPath()
    {
        var pathfinder = FindObjectOfType<Pathfinder>();
        path = pathfinder?.FindPath() ?? new List<Waypoint>();
    }

    private IEnumerator FollowPath()
    {
        foreach(var waypoint in path)
        {
            if (isDying) break; //prevents enemy to continue movement when dying

            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(frequency);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 1)
            KillEnemy();
    }

    private void ProcessHit()
    {
        //scoreBoard.ScoreHit(scorePerHit);
        hits--;
    }

    private void KillEnemy()
    {
        if (isDying) return; //prevents multiple deathFX instances

        isDying = true;
        var instantiatedFx = Instantiate(deathFx, transform.position, Quaternion.identity);
        instantiatedFx.transform.parent = parent;
        Destroy(gameObject);
    }
}