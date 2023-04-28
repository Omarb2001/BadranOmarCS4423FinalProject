using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShootingScript : MonoBehaviour
{
    public AudioSource shoot;
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
         //GameObject bullet;
         if(Time.time > lastShootTime + fireRate){
                shoot.Play();
                //bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
                if (bullet != null) {
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.rotation = firePoint.transform.rotation;
                bullet.SetActive(true);
                }
                
                lastShootTime = Time.time;
                //Destroy(bullet, range);
            }
    }
}
