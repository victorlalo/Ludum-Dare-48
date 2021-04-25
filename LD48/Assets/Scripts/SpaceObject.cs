using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    [SerializeField] GameObject[] spaceObjects;
    [SerializeField] float rotSpeed;
    [SerializeField] float force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        int itemNum = Random.Range(0, spaceObjects.Length);
        Instantiate(spaceObjects[itemNum], transform.position, Random.rotation, transform);

        rb.AddForce(Random.Range(-1f, 1f) * force, Random.Range(-1f, 1f) * force, Random.Range(-1f, 1f) * force, ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(Vector3.one * Time.deltaTime * rotSpeed);
    }
}
