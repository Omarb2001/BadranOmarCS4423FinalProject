using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapProjectileGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    private float lastShootTime = 0;
     public GameObject spikePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastShootTime + 2f){
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot(){
        GameObject bul1 = Instantiate(spikePrefab, firePoint.position, firePoint.rotation);
        Destroy(bul1, 2);
    }
}
