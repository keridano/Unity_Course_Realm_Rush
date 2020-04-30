using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;

    public bool isExplored;
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

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top Quad").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

}
