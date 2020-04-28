using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float dwellTime = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
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
