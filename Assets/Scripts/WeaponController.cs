using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponClass weaponObject;
    public Transform shootPoint;
    GameObject bullet;
    private float curveDeltaTime = 0.0f;

    //public float angle;

    public void Shoot(float angle)
    {
        Vector3 pos = shootPoint.position;
        pos += shootPoint.transform.up * (Mathf.Sin(Time.time * weaponObject.sinAngle) * weaponObject.waveRate);
        bullet = Instantiate(weaponObject.bulletPrefab, pos, transform.rotation);
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<BulletController>().StartBullet(weaponObject.bulletSpeed, weaponObject.damage, transform.root.gameObject);
    }

    private void Update()
    {

    }

}
