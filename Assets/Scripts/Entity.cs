using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public int curHealth;
    public int maxHealth;
    public Slider healthBar;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public virtual void OnDamaged(int damageAmount)
    {
        //Debug.Log("Damaged!");
        curHealth -= damageAmount;
        if (curHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Dead");
    }
}
