using UnityEngine;

public class RangedEnemyControl : MonoBehaviour
{
    private Rigidbody meleeRb;
    private GameObject player;
    private float speed = 10.0f;
    private float startShooting = 2.0f;
    private float reloadSpeed = 3.0f;
    private float playerDistance = 20.0f;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        meleeRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        InvokeRepeating("ShootProjectile", startShooting, reloadSpeed);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - transform.position).magnitude < playerDistance)
        {
            meleeRb.AddForce((transform.position - player.transform.position).normalized * speed);
        }

        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        ProjectileBehavior projectileScript = projectile.GetComponent<ProjectileBehavior>();
        projectileScript.shooter = this.gameObject;
    }
}
