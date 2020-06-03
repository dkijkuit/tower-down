using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    
    public float fireRate = 1f;

    private float fireCountDown = 1f;

    public float rotationSpeed = 10f;

    public int damage = 1;

    [Header("Unity setup fields")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    private Transform firePoint;
    
    private Transform partToRotate;

    // Start is called before the first frame update
    void Start()
    {
        partToRotate = transform.Find("PartToRotate");
        if(partToRotate == null) throw new System.Exception("Could not find partToRotate transform!");

        firePoint = partToRotate.Find("Firepoint");
        if(firePoint == null) throw new System.Exception("Could not find firePoint transform!");

        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void UpdateTarget(){
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        bool enemyInRange = false;
        if(target != null){
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if(distanceToEnemy <= range){
               enemyInRange = true; 
            }
        }
        
        if(!enemyInRange){
            foreach(GameObject enemy in enemies){
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if(distanceToEnemy < shortestDistance){
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null && shortestDistance <= range){
                if(target == null || nearestEnemy.transform != target.transform){
                    Debug.Log("Found new enemy!");
                    target = nearestEnemy.transform;
                } else {
                    target = null;
                }
            } else {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null) return;
    
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation =  Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);

        if(fireCountDown <= 0f){
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot(){
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.SetDamage(damage);

        if(bullet != null) bullet.SetTarget(target);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
