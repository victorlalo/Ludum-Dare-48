using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool spawning = true;
    [SerializeField] private float radius = 50;
    [SerializeField] GameObject spaceObjectPrefab;
    [SerializeField] float spawnDelay = 1f;
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (spawning)
        {
            Vector3 unitSemiCircle = Random.onUnitSphere;
            unitSemiCircle = new Vector3(unitSemiCircle.x, Mathf.Abs(unitSemiCircle.y), 0);

            Instantiate(spaceObjectPrefab, unitSemiCircle * radius, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
