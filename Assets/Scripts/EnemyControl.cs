using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // ENCAPSULATION
    protected Rigidbody Rb;
    protected GameObject player;
    protected float speed;

    void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOutOfBounds();
    }

    // ABSTRACTION
    protected void CheckOutOfBounds()
    {
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    // POLYMORPHISM
    protected virtual void Move()
    {
        Rb.AddForce((player.transform.position - transform.position).normalized * speed);       
    }
}
