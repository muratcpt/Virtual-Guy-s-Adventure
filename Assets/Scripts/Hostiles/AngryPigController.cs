using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPigController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float runSpeed = 4f;

    [Header("Patrol Points")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;

    [Header("Player Detection")]
    [SerializeField] private float detectionRange = 5f;
    private Transform player;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool movingRight = true;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && !isChasing)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer < detectionRange)
            {
                isChasing = true;
            }
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        // --- YENİ EKLENEN KISIM ---
        // Hangi durumda olursak olalım, yönümüzü hareketimize göre ayarla
        HandleFlipping();
        // --- BİTTİ ---

        anim.SetBool("isChasing", isChasing);
    }

    void Patrol()
    {
        // Bu fonksiyondan Flip() çağrıları kaldırıldı.
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(walkSpeed, rb.linearVelocity.y);
            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-walkSpeed, rb.linearVelocity.y);
            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
            }
        }
    }

    void ChasePlayer()
    {
        // Bu fonksiyondan spriteRenderer.flipX satırları kaldırıldı.
        // Artık sadece hızı belirliyor.
        if (transform.position.x < player.position.x)
        {
            rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
        }
        else if (transform.position.x > player.position.x)
        {
            rb.linearVelocity = new Vector2(-runSpeed, rb.linearVelocity.y);
        }
    }

    // --- YENİ EKLENEN FONKSİYON ---
    private void HandleFlipping()
    {
        // Eğer yatay hızımız sağa doğruysa sağa bak (flipX = false)
        if (rb.linearVelocity.x > 0.01f)
        {
            spriteRenderer.flipX = true;
        }
        // Eğer yatay hızımız sola doğruysa sola bak (flipX = true)
        else if (rb.linearVelocity.x < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        // Not: Eğer hız 0'a çok yakınsa, yönünü değiştirme. Bu, durduğunda titremesini engeller.
    }
    
    // Not: Artık private void Flip() fonksiyonu yok, sildik.

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}