using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class enemy : Entity
{
	[SerializeField] Transform targetDestination;
	[SerializeField] float speed;
	[SerializeField] float stoppingDistance;
	[SerializeField] GameObject bullet;
	[SerializeField] Transform shootPoint;
	[SerializeField] float attackCooldown;
	[SerializeField] float bulletSpeed;
	[SerializeField] int damage;
	[SerializeField] bool canFireBullets;
	bool canAttack;

	Rigidbody2D rgdbd2d;
	float lastShot;
	Vector2 direction;

	private void Awake()
	{
		rgdbd2d = GetComponent<Rigidbody2D>();
		healthBar.maxValue = maxHealth;
		healthBar.value = maxHealth;
	}

	private void Update()
	{
		if (Time.time - lastShot > attackCooldown)
		{
			if (canFireBullets)
			{
				lastShot = Time.time;
				Shoot();
			}
			else
            {
				canAttack = true;
            }
		}
		else
        {
			canAttack = false;
		}
	}

    private void FixedUpdate()
	{
		direction = (targetDestination.position - transform.position).normalized;
		//Debug.Log(Vector2.Distance(targetDestination.position, transform.position));
		if (Vector2.Distance(targetDestination.position, transform.position) > stoppingDistance)
		{
			rgdbd2d.velocity = direction * speed;
			canAttack = false;
		}
		else
        {
			rgdbd2d.velocity = Vector2.zero;
			if(canAttack)
            {
				lastShot = Time.time;
				targetDestination.gameObject.GetComponent<Entity>().OnDamaged(damage);
            }
        }
	}

    public override void OnDamaged(int damageAmount)
    {
        base.OnDamaged(damageAmount);
		healthBar
			.DOValue(curHealth, 0.2f);
		Debug.Log(transform.name + " damaged!");

	}
    public override void Die()
    {
        base.Die();
		Debug.Log(transform.name + " died!");
		Destroy(this.gameObject);
	}

	void Shoot()
    {
		Quaternion q = Quaternion.FromToRotation(Vector3.right, direction);
		GameObject newBullet = Instantiate(bullet, shootPoint.position, q);
		newBullet.GetComponent<BulletController>().StartBullet(bulletSpeed, damage, transform.root.gameObject);
    }
}
