using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    const int gridSize = 10;

    public bool isPlaceable = true;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public Vector2Int GridPos
    {
        get
        {
            return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
        }
    }

    public int GridSize
    {
        get
        {
            return gridSize;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            var towerInstance = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            towerInstance.transform.parent = GameObject.Find("Towers").transform;
            isPlaceable = false;
        }
    }

}