using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;

    public float speed = 70f;

    public float damageRadius = 0f;

    private int damage = 1;

    public void SetTarget(Transform enemy){
        target = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); 
    }

    public void SetDamage(int damage){
        this.damage = damage;
    }

    private void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

        if(damageRadius > 0f){
            DamageEnemiesInRadius();
        } else {
            DamageEnemy(target.gameObject);
        }

        Destroy(effectInstance, 5f);
        Destroy(gameObject);
    }

    private void DamageEnemy(GameObject enemyGO){
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        if(enemy != null){
            enemy.InflictDamage(damage);
        } else {
            Debug.LogError("Missing enemy component on enemy: "+enemyGO);
        }
    }

    private void DamageEnemiesInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider collider in colliders){
            if(collider.tag == "Enemy"){
                GameObject enemyGO = collider.gameObject;
                DamageEnemy(enemyGO);
            }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
