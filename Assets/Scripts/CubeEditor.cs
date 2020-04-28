using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        var gridSize = waypoint.GridSize;
        transform.position = new Vector3
        {
            x = waypoint.GridPos.x * gridSize,
            y = 0f,
            z = waypoint.GridPos.y * gridSize
        };
    }

    private void UpdateLabel()
    {
        var labelText   = $"{waypoint.GridPos.x},{waypoint.GridPos.y}";
        var textMesh    = GetComponentInChildren<TextMesh>();
        textMesh.text   = labelText;
        gameObject.name = labelText;
    }

}
