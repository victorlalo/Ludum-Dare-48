using System.Collections;
using UnityEngine;

public class DistractionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject distractionPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 50;
    [SerializeField] private bool spawning = true;
    [SerializeField] private float spawnDelay = 5f;
    
    [Range(0, 30)]
    [SerializeField] private float distractionSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDistraction());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator SpawnDistraction()
    {
        while (spawning)
        {
            Vector3 unitSemiCircle = Random.onUnitSphere;
            unitSemiCircle = new Vector3(unitSemiCircle.x, Mathf.Abs(unitSemiCircle.y), 0);

            var distraction = 
                Instantiate(distractionPrefab, unitSemiCircle * radius + player.transform.position, Quaternion.identity).GetComponent<Distraction>();
            //Debug.Log(distraction.transform.position);
            distraction.Player = player.transform;
            distraction.Speed = distractionSpeed;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}