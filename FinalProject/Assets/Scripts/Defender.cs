 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] bool isActive = false;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float topPadding = 1.8f;
    [SerializeField] float botPadding = 0.5f;

    [SerializeField] GameObject Launcher;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileFiringPeriod = 1f;
    [SerializeField] float projectileSpeed = 2f;

    float yMin;
    float yMax;

    Animator animator;
    Coroutine fireCoroutine;

    private void Start()
    {
        SetupMoveBoundaries();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isActive)
        {
            Move();
            Fire();
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking", true);
            fireCoroutine = StartCoroutine(ShootContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isAttacking", false);
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator ShootContinuously()
    {
        while (true)
        {
            GameObject bullet = Instantiate(projectilePrefab, Launcher.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + botPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - topPadding;
    }

    private void Move()
    {
        if (animator.GetBool("isAttacking") == false)
        {
            var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            if (deltaY != 0)
            {
                var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
                transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
            }
        }

    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
