 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] bool isActive = false;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float topPadding = 1.8f;
    [SerializeField] float botPadding = 0.5f;

    [Header("Projectiles")]
    [SerializeField] GameObject Launcher;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileFiringPeriod = 1f;
    [SerializeField] float projectileSpeed = 2f;

    [Header("SFX")]
    [SerializeField] AudioClip shootSound;
    [SerializeField] float shootsoundVol = 0.15f;

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
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootsoundVol);
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
                animator.SetBool("isMoving", true);
                var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
                transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
            }
            else
            {
                animator.SetBool("isMoving", false);
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
