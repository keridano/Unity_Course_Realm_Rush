using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower towerPrefab;

    readonly Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimit)
            InstantiateNewTower(baseWaypoint);
        else
            MoveExistingTower(baseWaypoint);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        newBaseWaypoint.isPlaceable = false;
        oldTower.CurrentBaseWaypoint.isPlaceable = true;

        oldTower.transform.position = newBaseWaypoint.transform.position;
        oldTower.CurrentBaseWaypoint = newBaseWaypoint;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = GameObject.Find("Towers").transform;

        waypoint.isPlaceable = false;
        newTower.CurrentBaseWaypoint = waypoint;
        towerQueue.Enqueue(newTower);
    }
}
