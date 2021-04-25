using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private new Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        // rigidbody.velocity = rigidbody.transform.up * speed;
        // rigidbody.AddForce(rigidbody.transform.up * (speed * Time.deltaTime));
        transform.Translate(transform.up * (speed * Time.deltaTime));
    }
}
