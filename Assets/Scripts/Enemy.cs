using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 5;

    public uint cashReward = 10;

    public uint damage = 1;

    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1) {
            endPath();
            return;
        }
        
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    public void InflictDamage(int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        PlayerStats.instance.AddMoney(cashReward);
        GameObject deathEffectGO = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectGO, 5f);
        Destroy(gameObject);
    }

    void endPath(){
        PlayerStats.instance.TakeLives((int)this.damage);
        Debug.Log("Enemy got to destination inflicting damage: "+this.damage);
        Destroy(gameObject);
    }
}
