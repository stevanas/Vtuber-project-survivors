using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponClass weaponObject;
    public Transform shootPoint;
    GameObject bullet;
    private float curveDeltaTime = 0.0f;
    float inaccuracyAmount;
    int curBullets;


    //public float angle;
    private void Start()
    {
        curBullets = weaponObject.magazineSize;
        GameManager.instance.UpdateWeaponUI(curBullets, weaponObject.magazineSize);
    }

    public void Shoot(float angle)
    {
        if (curBullets > 0)
        {
            Vector3 pos = shootPoint.position;
            pos += shootPoint.transform.up * (Mathf.Sin(Time.time * weaponObject.sinAngle) * weaponObject.waveRate);
            bullet = Instantiate(weaponObject.bulletPrefab, pos, transform.rotation);
            inaccuracyAmount = Random.Range(-weaponObject.inaccuracyAngle, weaponObject.inaccuracyAngle);
            bullet.transform.rotation = Quaternion.AngleAxis(angle + inaccuracyAmount, Vector3.forward);
            bullet.GetComponent<BulletController>().StartBullet(weaponObject.bulletSpeed, weaponObject.damage, transform.root.gameObject);
            curBullets--;
            GameManager.instance.UpdateWeaponUI(curBullets, weaponObject.magazineSize);
            if (curBullets <= 0)
            {
             StartCoroutine(Reload());
            }
        }
    }
    IEnumerator Reload()
    {
        //Play reload animation
        GameManager.instance.UpdateWeaponUI(-100, weaponObject.magazineSize);
        yield return new WaitForSeconds(weaponObject.reloadTime);
        curBullets = weaponObject.magazineSize;
        GameManager.instance.UpdateWeaponUI(curBullets, weaponObject.magazineSize);
    }

    private void Update()
    {

    }

}
