using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float range = 0.25f;
    // Update is called once per frame

    public float fireRate = 0.25f;
    public float lastShootTime = 0.25f;

    void Update()
    {
        if (Input.GetButton("Fire1")){
            if(LevelOneScript.paused) return;
            Shoot();
        }
    }

    void Shoot(){
         GameObject bullet;
         if(Time.time > lastShootTime + fireRate){
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                lastShootTime = Time.time;
                Destroy(bullet, range);
            }
    }
}
