using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;

    public GameObject bulletPrefab;

    private float fireRate = 0.75f;
    private float lastShootTime;
    public float range = 0.20f;
    
    // Update is called once per frame
    void Update()
    {   
        
        if (Input.GetButtonDown("Fire1") && Time.time > lastShootTime + fireRate){
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot(){
        
        GameObject bul1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bul2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bul3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bul4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        GameObject bul5 = Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
        Destroy(bul1, range);
        Destroy(bul2, range);
        Destroy(bul3, range);
        Destroy(bul4, range);
        Destroy(bul5, range);


    }
}

