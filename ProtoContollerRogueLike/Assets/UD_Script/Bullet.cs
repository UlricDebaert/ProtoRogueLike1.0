using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime;
    float lifeTimer;

    private void Start()
    {
        lifeTimer = 0.0f;
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
