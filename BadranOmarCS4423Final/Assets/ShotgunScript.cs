using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ShotgunScript : MonoBehaviour
{
    public AudioSource shoot;
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
            shoot.Play();
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot(){
        
        GameObject bul1 = ObjectPool.SharedInstance.GetPooledObject();
        if (bul1 != null) {
            bul1.transform.position = firePoint1.transform.position;
            bul1.transform.rotation = firePoint1.transform.rotation;
            bul1.SetActive(true);
        }
        GameObject bul2 = ObjectPool.SharedInstance.GetPooledObject();
        if (bul2 != null) {
            bul2.transform.position = firePoint2.transform.position;
            bul2.transform.rotation = firePoint2.transform.rotation;
            bul2.SetActive(true);
        }
        GameObject bul3 = ObjectPool.SharedInstance.GetPooledObject();
        if (bul3 != null) {
            bul3.transform.position = firePoint3.transform.position;
            bul3.transform.rotation = firePoint3.transform.rotation;
            bul3.SetActive(true);
        }
        GameObject bul4 = ObjectPool.SharedInstance.GetPooledObject();
        if (bul4 != null) {
            bul4.transform.position = firePoint4.transform.position;
            bul4.transform.rotation = firePoint4.transform.rotation;
            bul4.SetActive(true);
        }
        GameObject bul5 = ObjectPool.SharedInstance.GetPooledObject();
        if (bul5 != null) {
            bul5.transform.position = firePoint5.transform.position;
            bul5.transform.rotation = firePoint5.transform.rotation;
            bul5.SetActive(true);
        }
        //Destroy(bul1, range);
        //Destroy(bul2, range);
        //Destroy(bul3, range);
        //Destroy(bul4, range);
        //Destroy(bul5, range);


    }
}

