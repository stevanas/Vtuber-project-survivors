using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    //public AnimationCurve bulletCurve;
    public float rate;
    public float pathWaveHeight;
    public float sinAngle;
    float curEval = 0;
    int bulletDamage;
    GameObject owner;
    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //StartBullet();
    }

    public void StartBullet(float bulletSpeed, int damage, GameObject entity)
    {
        rb.AddForce(transform.right * bulletSpeed);
        bulletDamage = damage;
        owner = entity;
        Destroy(this.gameObject, 2f);
    }
    private void OnDestroy()
    {
        DOTween.Complete(this);
        //DOTween.Kill(this);
        //DOTween.Clear(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name + owner.name);
        if (collision.CompareTag("Damageable") && collision.gameObject != owner)
        {
            collision.GetComponent<Entity>().OnDamaged(bulletDamage);
        }
    }
}
