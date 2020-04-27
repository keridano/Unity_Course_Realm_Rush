using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;

    void Update()
    {
        transform.position = new Vector3
        {
            x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            y = 0f,
            z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        };
    }
}
