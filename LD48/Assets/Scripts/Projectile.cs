using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private new Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.up * speed, ForceMode.Impulse);
        
    }

    private void Update()
    {
        // rigidbody.velocity = rigidbody.transform.up * speed;
        // rigidbody.AddForce(rigidbody.transform.up * (speed * Time.deltaTime));
        //transform.Translate(transform.up * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Distraction>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // signal/event that distraction was destroyed
        }
    }
}
