using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float force = 5f;
    bool exploded = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D col;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        Invoke("Explode", 2f);
    }

    void Explode()
    {
        exploded = true;
        Destroy(gameObject, 1f);
    }

    public void ApplyForce(Rigidbody2D otherBody)
    {
        if (!exploded) return;
        Vector3 direction = otherBody.transform.position - transform.position;
        otherBody.AddForceAtPosition(direction * force, transform.position, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.gameObject.tag);
            ApplyForce(other.attachedRigidbody);
        }
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (tag == "Player")
    //         Debug.Log(other.gameObject.name + " TRIGGER STAY");
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (tag == "Player")
    //         Debug.Log(other.gameObject.name + " TRIGGER EXIT");
    // }
}