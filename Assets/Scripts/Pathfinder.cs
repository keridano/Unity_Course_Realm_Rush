using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Waypoint startWaypoint, endWaypoint;
#pragma warning restore 0649
    bool isRunning = true;

    readonly List<Waypoint> path = new List<Waypoint>();
    readonly Queue<Waypoint> queue = new Queue<Waypoint>();
    readonly Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    readonly Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    Waypoint searchCenter;

    public List<Waypoint> FindPath()
    {
        LoadBlocks();
        //ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (var waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GridPos))
                Debug.Log($"Skipping overlapping block {waypoint.name}");
            else
                grid.Add(waypoint.GridPos, waypoint);
        }
    }

    //private void ColorStartAndEnd()
    //{
    //    startWaypoint.SetTopColor(Color.green);
    //    endWaypoint.SetTopColor(Color.red);
    //}

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

    }

    private void CreatePath()
    {
        path.Add(endWaypoint);
        var previousWaypoint = endWaypoint.exploredFrom;

        while(previousWaypoint != startWaypoint)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void HaltIfEndFound()
    {
        isRunning &= searchCenter != endWaypoint;
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;

        foreach(var direction in directions)
        {
            Vector2Int neighbourPos = searchCenter.GridPos + direction;
            if (grid.ContainsKey(neighbourPos))
            {
                var neighbour = grid[neighbourPos];
                if (neighbour.isExplored || queue.Contains(neighbour)) continue;

                neighbour.exploredFrom = searchCenter;
                queue.Enqueue(neighbour);
            }
        }
    }

}