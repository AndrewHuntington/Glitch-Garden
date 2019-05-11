using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 50f)] [SerializeField] float moveSpeed = 5f;
    [Range(0f, 720f)] [SerializeField] float rotateSpeed = 360f;
    [SerializeField] float damage = 50f;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        //Rick's code (used in Update)
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Rotate()
    {
        transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

        
    }
}
