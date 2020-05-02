using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Transform objectToPan;
#pragma warning restore 0649
    [SerializeField] float attackRange = 30f;

    ParticleSystem towerGun;
    Transform targetEnemy;

    void Start()
    {
        towerGun = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy != null)
            FireAtEnemy();
        else
            Shoot(false);
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();
        if (enemies == null || enemies.Length == 0)
        {
            targetEnemy = null;
            return;
        }

        var closestEnemy = enemies[0].transform;
        foreach(var candidateEnemy in enemies)
        {
            if (candidateEnemy == closestEnemy) continue; //Skip the first enemy
            closestEnemy = GetClosestEnemy(closestEnemy, candidateEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform candidateEnemy)
    {
        var distanceToClosestEnemy = Vector3.Distance(closestEnemy.position, gameObject.transform.position);
        var distanceToCandidateEnemy = Vector3.Distance(candidateEnemy.position, gameObject.transform.position);
        return distanceToClosestEnemy <= distanceToCandidateEnemy ? closestEnemy : candidateEnemy;
    }

    private void FireAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
        var distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
        Shoot(distanceToEnemy < attackRange);
    }

    private void Shoot(bool shootingEnabled)
    {
        var emission = towerGun.emission;
        emission.enabled = shootingEnabled;
    }
}