using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MinigunScript : MonoBehaviour
{
    public AudioSource shoot;
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
         Debug.Log(MainMenuScript.damage);
            if(Time.time > lastShootTime + fireRate){
                
            shoot.Play();
            //GameObject bul1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            //GameObject bul2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            //GameObject bul3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

            GameObject bullet1 = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet1 != null) {
                bullet1.transform.position = firePoint1.transform.position;
                bullet1.transform.rotation = firePoint1.transform.rotation;
                bullet1.SetActive(true);
            }
            GameObject bullet2 = ObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet2 != null) {
                bullet2.transform.position = firePoint2.transform.position;
                bullet2.transform.rotation = firePoint2.transform.rotation;
                bullet2.SetActive(true);
            }
            GameObject bullet3 = ObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet1 != null && bullet2 != null && bullet3 != null) {
                bullet3.transform.position = firePoint3.transform.position;
                bullet3.transform.rotation = firePoint3.transform.rotation;
                bullet3.SetActive(true);
            }
            lastShootTime = Time.time;
            //Destroy(bul1, range);
            //Destroy(bul2, range);
            //Destroy(bul3, range);
            }
    }
}
