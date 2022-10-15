using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        StartBullet();
    }

    public void StartBullet()
    {
        rb.velocity = rb.transform.right * bulletSpeed;
        Destroy(this.gameObject, 2f);
    }
}
