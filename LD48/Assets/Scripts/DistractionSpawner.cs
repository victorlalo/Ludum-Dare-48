using System.Collections;
using UnityEngine;

public class DistractionSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] distractionPrefabs;
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 50;
    [SerializeField] private bool spawning = true;
    [SerializeField] private float spawnDelay = 5f;

    [Range(0, 30)]
    [SerializeField] private float distractionSpeed = 5f;

    [SerializeField] float iconScale;


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

            var distractionGameObject =
                Instantiate(distractionPrefabs[Random.Range(0, distractionPrefabs.Length)], unitSemiCircle * radius + player.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

            distractionGameObject.transform.localScale *= iconScale;

            var distraction = distractionGameObject.GetComponent<Distraction>();
            // distractionGameObject.transform.Rotate(distraction.transform.up, 90);
            //Debug.Log(distraction.transform.position);
            distraction.Player = player.transform;
            distraction.Speed = distractionSpeed;
            distraction.Text = "placeholder";
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
