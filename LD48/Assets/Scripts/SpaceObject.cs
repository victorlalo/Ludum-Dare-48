using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] GameObject[] spaceObjects;
    [SerializeField] float rotSpeed;
    [SerializeField] float force;
    Rigidbody rb;
    
    public float XForce { get; set; }
    public float YForce { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        int itemNum = Random.Range(0, spaceObjects.Length);
        Instantiate(spaceObjects[itemNum], transform.position, Random.rotation, transform);

        // var xForce = transform.position.x > 0 ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);
        // var yForce = transform.position.y < 0 ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);
        
        rb.AddForce(XForce * force, YForce * force, Random.Range(-1f, 1f) * force, ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(Vector3.one * Time.deltaTime * rotSpeed);
    }
}
