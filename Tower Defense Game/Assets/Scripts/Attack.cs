using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Transform target;
    public float range = 10f;
    public string enemyTag = "Enemy";

    public Transform TowerRotation;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FindTarget", 0f, 0.5f);
	}

    void FindTarget() {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            //EnemySpecs specs = enemy.GetComponent<EnemySpecs>();
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }

        Vector3 dirToEnemy = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dirToEnemy);
        Vector3 rotation = targetRotation.eulerAngles;
        TowerRotation.rotation = Quaternion.Euler (0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
