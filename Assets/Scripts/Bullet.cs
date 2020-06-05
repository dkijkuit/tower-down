using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;

    public float speed = 70f;

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
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
        Enemy enemy = target.gameObject.GetComponent<Enemy>();
        enemy.InflictDamage(damage);
    }
}
