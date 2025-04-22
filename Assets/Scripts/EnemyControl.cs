using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody meleeRb;
    private GameObject player;
    private float speed = 10.0f;

    void Awake()
    {
        meleeRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        meleeRb.AddForce((player.transform.position - transform.position).normalized * speed);
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
