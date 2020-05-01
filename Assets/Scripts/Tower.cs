using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
