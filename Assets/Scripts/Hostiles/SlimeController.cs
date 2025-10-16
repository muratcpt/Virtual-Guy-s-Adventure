using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Düşmanın hızı
    [SerializeField] private Transform leftPoint; // Sol devriye noktası
    [SerializeField] private Transform rightPoint; // Sağ devriye noktası

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool movingRight = true; // Başlangıçta sağa mı gidiyor?

    void Start()
    {
        // Gerekli bileşenleri alıyoruz
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Hareketi yönet
        Move();
        
        // Sınırlara ulaşıldı mı kontrol et ve yön değiştir
        CheckBounds();
    }

    private void Move()
{
    if (movingRight)
    {
        // Sağa hareket et
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); // YENİ KULLANIM
    }
    else
    {
        // Sola hareket et
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y); // YENİ KULLANIM
    }
}

    private void CheckBounds()
    {
        // Eğer sağa gidiyorsa ve sağ noktanın ilerisine geçtiyse
        if (movingRight && transform.position.x >= rightPoint.position.x)
        {
            // Yön değiştir ve sprite'ı çevir
            movingRight = false;
            Flip();
        }
        // Eğer sola gidiyorsa ve sol noktanın gerisine geçtiyse
        else if (!movingRight && transform.position.x <= leftPoint.position.x)
        {
            // Yön değiştir ve sprite'ı çevir
            movingRight = true;
            Flip();
        }
    }

    private void Flip()
    {
        // Sprite'ın X eksenindeki yönünü tersine çevirir
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}