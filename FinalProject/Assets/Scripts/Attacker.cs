using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
