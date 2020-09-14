﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject gatlingBulletPrefab;
    public GameObject shootgunBulletPrefab;

    public float bulletForce = 20.0f;
    public float shootgunBulletForce = 15.0f;
    public float gatlingFireRate = 0.1f;
    public float shootgunFireRate = 0.1f;
    float fireRateTimer;

    private bool canShoot;
    private bool gatlingEquiped;
    private bool shootgunEquiped;

    private bool gatlingOnFire;
    private bool shootgunOnFire;

    private void Start()
    {
        gatlingEquiped = true;
        shootgunEquiped = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot && gatlingEquiped)
        {
            GatlingShoot();
            canShoot = false;
            fireRateTimer = gatlingFireRate;
        }

        if (Input.GetButton("Fire1") && canShoot && shootgunEquiped)
        {
            ShootgunShoot();
            canShoot = false;
            fireRateTimer = shootgunFireRate;
        }

        if (!canShoot)
        {
            fireRateTimer -= Time.deltaTime;
            if (fireRateTimer < 0.0f)
            {
                canShoot = true;
            }
        }

        ChangeWeapon();

    }

    void GatlingShoot()
    {
        GameObject bullet = Instantiate(gatlingBulletPrefab, firePoint1.position, firePoint1.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootgunShoot()
    {
        GameObject bullet1 = Instantiate(shootgunBulletPrefab, firePoint1.position, firePoint1.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(shootgunBulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(shootgunBulletPrefab, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gatlingOnFire == true)
        {
            ChangeToShootgun();
        }

        if (Input.GetKeyDown(KeyCode.Q) && shootgunOnFire == true)
        {
            ChangeToGatling();
        }

        if (gatlingEquiped)
        {
            gatlingOnFire = true;
            shootgunOnFire = false;
        }

        if (shootgunEquiped)
        {
            gatlingOnFire = false;
            shootgunOnFire = true;
        }
    }

    void ChangeToGatling()
    {
        gatlingEquiped = true;
        shootgunEquiped = false;
    }

    void ChangeToShootgun()
    {
        gatlingEquiped = false;
        shootgunEquiped = true;
    }
}
