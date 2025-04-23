using UnityEngine;

// INHERITANCE
public class RangedEnemyControl : EnemyControl
{
    private float startShooting = 2.0f;
    private float reloadSpeed = 3.0f;
    private float playerDistance = 30.0f;
    public GameObject projectilePrefab;
    void Start()
    {
        speed = 15.0f;
        InvokeRepeating("ShootProjectile", startShooting, reloadSpeed);
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        ProjectileBehavior projectileScript = projectile.GetComponent<ProjectileBehavior>();
        projectileScript.shooter = this.gameObject;
    }

    protected override void Move()
    {
        if((player.transform.position - transform.position).magnitude < playerDistance)
        {
            Rb.AddForce((transform.position - player.transform.position).normalized * speed);
        }
    }
}
