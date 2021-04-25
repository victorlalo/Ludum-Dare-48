using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DistractionSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] distractionPrefabs;
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 50;
    [SerializeField] private bool spawning;
    [SerializeField] private float spawnDelay = 5f;

    [Range(0, 30)]
    [SerializeField] private float distractionSpeed = 5f;

    [SerializeField] float iconScale;
    
    private List<Distraction> spawnedDistractions = new List<Distraction>();
    
    public delegate void StopSpawningEventHandler();
    public static event StopSpawningEventHandler OnStopSpawning;
    private IEnumerator SpawnDistraction()
    {
        while (spawning)
        {
            Vector3 unitSemiCircle = Random.onUnitSphere;
            unitSemiCircle = new Vector3(unitSemiCircle.x, Mathf.Abs(unitSemiCircle.y), 0);

            var distractionGameObject =
                Instantiate(distractionPrefabs[Random.Range(0, distractionPrefabs.Length)], unitSemiCircle * radius + player.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

            distractionGameObject.transform.localScale *= iconScale;

            var distraction = distractionGameObject.GetComponent<Distraction>();
            spawnedDistractions.Add(distraction);
            // distractionGameObject.transform.Rotate(distraction.transform.up, 90);
            //Debug.Log(distraction.transform.position);
            distraction.Player = player.transform;
            distraction.Speed = distractionSpeed;
            distraction.Text = Thoughts.GetRandomThought();
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void StartSpawning()
    {
        spawning = true;
        StartCoroutine(SpawnDistraction());
    }
    
    public void StopSpawning()
    {
        spawning = false;
        OnStopSpawning?.Invoke();
    }
}
