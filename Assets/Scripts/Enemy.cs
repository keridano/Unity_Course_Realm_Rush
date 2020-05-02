﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Death & Collisions")]
#pragma warning disable 0649
    [SerializeField] GameObject deathFx;
#pragma warning restore 0649
    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hits = 80;
    bool isDying;

    [Header("Movement")]
    [SerializeField] float frequency = 1f;
    List<Waypoint> path;

    void Start()
    {
        SetupEnemyPath();
        StartCoroutine(FollowPath());
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
        if (hits <= 0)
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
        instantiatedFx.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}