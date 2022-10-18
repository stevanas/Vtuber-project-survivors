using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/New Weapon Object", order = 1)]


public class WeaponClass : ScriptableObject
{
    //public Sprite sprite;
    public GameObject bulletPrefab;
    [Range(2,0)]
    public float fireRate;
    public float bulletSpeed;
    public int damage;
    [Space(10)]
    public float sinAngle; //= 0 for staight line
    public float waveRate; //= 0 for staight line
    public bool isAutomatic;
    public float inaccuracyAngle;
    [Space(10)]
    public int magazineSize;
    public float reloadTime;
}
