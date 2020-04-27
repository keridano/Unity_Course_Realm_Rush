using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        textMesh = GetComponentInChildren<TextMesh>();

        transform.position = new Vector3
        {
            x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            y = 0f,
            z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        };

        textMesh.text = $"{transform.position.x / gridSize},{transform.position.z / gridSize}";
    }
}
