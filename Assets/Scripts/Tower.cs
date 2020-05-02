using UnityEngine;

public class Tower : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
#pragma warning restore 0649

    ParticleSystem towerGun;

    void Start()
    {
        towerGun = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        if (targetEnemy != null)
            objectToPan.LookAt(targetEnemy);
        else
        {
            var emission = towerGun.emission;
            emission.enabled = false;
        }
    }
}