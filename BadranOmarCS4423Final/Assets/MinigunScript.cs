using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunScript : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    public float range = 0.25f;
    public float fireRate = 0.1f;
    public float lastShootTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
            if(Time.time > lastShootTime + fireRate){
            GameObject bul1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            GameObject bul2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            GameObject bul3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            lastShootTime = Time.time;
            Destroy(bul1, range);
            Destroy(bul2, range);
            Destroy(bul3, range);
            }
    }
}
