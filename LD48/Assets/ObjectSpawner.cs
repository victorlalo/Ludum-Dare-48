using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool spawning = true;
    [SerializeField] GameObject spaceObjectPrefab;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] private new Camera camera;
    
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (spawning)
        {
            var xPos = CoinFlip() ? Random.Range(-100, -1) : Random.Range(Screen.width + 1, Screen.width + 100);
            var yPos = CoinFlip() ? Random.Range(-100, -1) : Random.Range(Screen.height + 1, Screen.height + 100);
            Vector3 screenPosition = camera.ScreenToWorldPoint(new Vector3(xPos, yPos, camera.farClipPlane/2));
            
            Instantiate(spaceObjectPrefab, screenPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private bool CoinFlip()
    {
        return Random.value > 0.5;
    }
}
