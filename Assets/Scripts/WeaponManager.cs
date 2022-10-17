using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //List<>
    public WeaponController curWeapon;
    Vector2 mousePos;
    PlayerMover mover;
    Rigidbody2D weaponRb;
    bool canShoot = true;
    float lastShot;
    InputHandler input;
    float angle;
    private void Start()
    {
        mover = GetComponent<PlayerMover>();
        weaponRb = curWeapon.GetComponent<Rigidbody2D>();
        input = InputHandler.instance;

    }
    private void Update()
    {
        mousePos = mover.cam.ScreenToWorldPoint(Input.mousePosition);


        if(Time.time - lastShot > curWeapon.weaponObject.fireRate)
        {
            if(canShoot)
            {
                if(input.leftClickHeld)
                {
                    if (!curWeapon.weaponObject.isAutomatic)
                    {
                        canShoot = false;
                    }
                    curWeapon.Shoot(angle);
                    lastShot = Time.time;
                }
            }
            else
            {
                if(input.leftClickUp)
                {
                    canShoot = true;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = (mousePos - weaponRb.position).normalized;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        curWeapon.transform.eulerAngles = new Vector3(0,0,angle);
    }
}
