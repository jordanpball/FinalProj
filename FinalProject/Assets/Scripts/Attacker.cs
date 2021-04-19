using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    float currentSpeed;

    private void Start()
    {
        currentSpeed = moveSpeed;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
