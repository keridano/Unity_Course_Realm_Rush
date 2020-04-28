using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (var waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GridPos))
            {
                Debug.Log($"Skipping overlapping block {waypoint.name}");
            } else
                grid.Add(waypoint.GridPos, waypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
