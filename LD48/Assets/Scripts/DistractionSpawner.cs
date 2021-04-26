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

    [SerializeField] GameObject debugCube;
    public bool spawnOnAwake = false;

    private void Awake()
    {
        if (spawnOnAwake){
            StartSpawning();
        }
        
    }

    private IEnumerator SpawnDistraction()
    {
        while (spawning)
        {
            Vector3 unitSemiCircle = RandomCircle(transform.position, radius);
            //unitSemiCircle = new Vector3(unitSemiCircle.x, Mathf.Abs(unitSemiCircle.y), 0);
            if (unitSemiCircle.y < 0)
            {
                unitSemiCircle.y = -unitSemiCircle.y;
            }
            unitSemiCircle.z = 0;

            var distractionGameObject =
                Instantiate(distractionPrefabs[Random.Range(0, distractionPrefabs.Length)], unitSemiCircle * radius + player.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)), transform);

            //Instantiate(debugCube, unitSemiCircle * radius, Quaternion.Euler(new Vector3(0, 180, 0)), transform);

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

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    public void StartSpawning()
    {
        spawning = true;
        StartCoroutine(SpawnDistraction());
    }
    
    public void StopSpawning()
    {
        spawning = false;
        // OnStopSpawning?.Invoke();
        gameObject.SetActive(false);
    }
}
