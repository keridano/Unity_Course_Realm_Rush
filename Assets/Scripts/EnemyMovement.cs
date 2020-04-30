using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float dwellTime = 1f;

    List<Waypoint> path;

    void Start()
    {
        var pathfinder = FindObjectOfType<Pathfinder>();
        path = pathfinder.FindPath() ?? new List<Waypoint>();
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        print("starting patrol...");
        foreach(var waypoint in path)
        {
            print($"visiting block: {waypoint.name}");
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(dwellTime);
        }
        print("ending patrol...");
    }
}
