using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private SwordAttack SA;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform swordHitBoxPos;
    public GameObject gatlingBulletPrefab;
    public GameObject shootgunBulletPrefab;

    public float bulletForce = 20.0f;
    public float shootgunBulletForce = 15.0f;
    public float gatlingFireRate = 0.1f;
    public float shootgunFireRate = 0.1f;
    public float swordFireRate = 0.1f;
    public float pistolFireRate = 0.1f;
    float fireRateTimer;
    float pistolFireRateTimer;
    public float gatlingImprecision;
    public float shootgunImprecision;
    public float swordAttackRadius;

    private bool canShoot;
    private bool pistolCanShoot;
    private bool gatlingEquiped;
    private bool shootgunEquiped;
    private bool swordEquiped;

    private bool gatlingOnFire;
    private bool shootgunOnFire;
    private bool swordOnFire;

    private void Start()
    {
        gatlingEquiped = true;
        shootgunEquiped = false;
        swordEquiped = false;
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
        
        if (Input.GetButton("Fire1") && canShoot && swordEquiped)
        {
            SwordShoot();
            canShoot = false;
            fireRateTimer = swordFireRate;
        }
        if (Input.GetButton("Fire2") && canShoot && swordEquiped)
        {
            SwordShoot();
            pistolCanShoot = false;
            pistolFireRateTimer = pistolFireRate;
        }

        if (!canShoot)
        {
            fireRateTimer -= Time.deltaTime;
            if (fireRateTimer < 0.0f)
            {
                canShoot = true;
            }
        }
        
        if (!pistolCanShoot)
        {
            fireRateTimer -= Time.deltaTime;
            if (fireRateTimer < 0.0f)
            {
                pistolCanShoot = true;
            }
        }

        ChangeWeapon();

    }

    void GatlingShoot()
    {
        GameObject bullet = Instantiate(gatlingBulletPrefab, firePoint1.position, firePoint1.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-gatlingImprecision, gatlingImprecision)));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootgunShoot()
    {
        GameObject bullet1 = Instantiate(shootgunBulletPrefab, firePoint1.position, firePoint1.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootgunImprecision, shootgunImprecision)));
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet1.transform.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(shootgunBulletPrefab, firePoint2.position, firePoint2.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootgunImprecision, shootgunImprecision)));
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(bullet2.transform.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(shootgunBulletPrefab, firePoint3.position, firePoint3.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootgunImprecision, shootgunImprecision)));
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(bullet3.transform.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet4 = Instantiate(shootgunBulletPrefab, firePoint4.position, firePoint4.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootgunImprecision, shootgunImprecision)));
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(bullet4.transform.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet5 = Instantiate(shootgunBulletPrefab, firePoint5.position, firePoint5.rotation * Quaternion.Euler(0.0f, 0.0f, Random.Range(-shootgunImprecision, shootgunImprecision)));
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb5.AddForce(bullet5.transform.up * bulletForce, ForceMode2D.Impulse);
    }

    void SwordShoot()
    {
        if(SA != null)
        {
            SA.GetAttackInput();
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gatlingOnFire == true)
        {
            ChangeToShootgun();
        }

        if (Input.GetKeyDown(KeyCode.Q) && shootgunOnFire == true)
        {
            ChangeToSword();
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && swordOnFire == true)
        {
            ChangeToGatling();
        }

        if (gatlingEquiped)
        {
            gatlingOnFire = true;
            shootgunOnFire = false;
            swordOnFire = false;
        }

        if (shootgunEquiped)
        {
            gatlingOnFire = false;
            shootgunOnFire = true;
            swordOnFire = false;
        }

        if (swordEquiped)
        {
            gatlingOnFire = false;
            shootgunOnFire = false;
            swordOnFire = true;
        }
    }

    void ChangeToGatling()
    {
        gatlingEquiped = true;
        shootgunEquiped = false;
        swordEquiped = false;
    }

    void ChangeToShootgun()
    {
        gatlingEquiped = false;
        shootgunEquiped = true;
        swordEquiped = false;
    }
    
    void ChangeToSword()
    {
        gatlingEquiped = false;
        shootgunEquiped = false;
        swordEquiped = true;
    }
}

