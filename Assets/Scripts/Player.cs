using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public static Transform playerTransform;
    public float speed;
    public GameObject bullet;
    public float bulletSpeed;
    public GameObject model;
    public Animator animator;
    public AudioSource audioSource;

    private Vector3 shootDirection;
    private void Awake()
    {
        playerTransform = transform;
    }

    private void Update()   
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalAxis, 0, verticalAxis);

    //    animator.SetBool("isWalking", direction.magnitude > 0.1f);
        controller.Move(direction * speed * Time.deltaTime);
        
        model.transform.LookAt(transform.position + shootDirection);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(shootDirection);
        }
    }

    private void FixedUpdate()
    {
        shootDirection = GetShootingDirection();
    }

    private Vector3 GetShootingDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Ground"))
            {
                Vector3 direction = hit.point - transform.position;
                direction.y = 0;
                return direction.normalized;
            }
        }
        return Vector3.zero;
    }

    void Shoot(Vector3 dir)
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
        AudioManager.instance.PlayShootSound();
    }
}
