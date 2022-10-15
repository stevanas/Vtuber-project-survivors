using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/New Weapon Object", order = 1)]


public class WeaponClass : ScriptableObject
{
    //public Sprite sprite;
    public GameObject bulletPrefab;
    [Range(10,0)]
    public float fireRate;
    public bool isAutomatic;
}
