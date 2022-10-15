using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //List<>
    public GameObject curWeapon;
    Vector2 mousePos;
    PlayerMover mover;
    Rigidbody2D weaponRb;
    private void Start()
    {
        mover = GetComponent<PlayerMover>();
        weaponRb = curWeapon.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePos = mover.cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = (mousePos - weaponRb.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        curWeapon.transform.eulerAngles = new Vector3(0,0,angle);
    }
}
