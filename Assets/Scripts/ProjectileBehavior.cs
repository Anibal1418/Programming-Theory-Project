using UnityEngine;
using System.Collections;
public class ProjectileBehavior : MonoBehaviour
{
    private float projectileSpeed = 2.0f;
    private GameObject player;
    private Vector3 targetPosition;
    private Vector3 movement;
    public GameObject shooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shooter != null)
        {
            Collider projectileCollider = GetComponent<Collider>();
            Collider shooterCollider = shooter.GetComponent<Collider>();

            Physics.IgnoreCollision(shooterCollider, projectileCollider, true);
        }
        player = GameObject.Find("Player");
        targetPosition = player.transform.position;
        StartCoroutine(ProjectileLifetime());
        movement = (targetPosition - transform.position).normalized * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Solid" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ProjectileLifetime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
