using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponClass weaponObject;
    public Transform shootPoint;
    bool canShoot = true;
    InputHandler input;
    float lastShot;

    private void Start()
    {
        input = InputHandler.instance;
    }

    private void Update()
    {
        if(input.leftClickHeld)
        {
            if(!weaponObject.isAutomatic)
            {
                if (canShoot)
                {
                    canShoot = false;
                    Shoot();
                }
            }
            else
            {
                if(Time.time - lastShot > weaponObject.fireRate)
                {
                    lastShot = Time.time;
                    canShoot = true;
                }
                if(canShoot)
                {
                    canShoot = false;
                    Shoot();
                }
            }
        }
        else if(input.leftClickUp)
        {
            if(!weaponObject.isAutomatic)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(weaponObject.bulletPrefab, shootPoint.position, transform.rotation);
        //bullet.transform.GetComponent<BulletController>().StartBullet();
    }
}
