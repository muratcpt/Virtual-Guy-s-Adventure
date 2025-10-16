using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    [SerializeField] private AudioSource deathSoundEffect;

    // --- YENİ EKLENEN KISIM ---
    public int maxHealth = 3;
    public int currentHealth;

    // UI yöneticisi için bir referans (bir sonraki adımda oluşturacağız)
    public HealthUIManager healthUIManager;
    // --- BİTTİ ---

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        // --- YENİ EKLENEN KISIM ---
        currentHealth = maxHealth;
        // Başlangıçta UI'ı güncellemek için
        if (healthUIManager != null)
        {
            healthUIManager.UpdateHealthUI(currentHealth);
        }
        // --- BİTTİ ---
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // Die() yerine TakeDamage çağırıyoruz.

            TakeDamage(1);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(3);
        }
    }

    // --- YENİ EKLENEN FONKSİYON ---
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // UI'ı güncelle
        if (healthUIManager != null)
        {
            healthUIManager.UpdateHealthUI(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        // İstersen buraya bir hasar alma sesi veya animasyonu da ekleyebilirsin.
    }
    // --- BİTTİ ---

    public void Die()
    {
        deathSoundEffect.Play();
        rb2d.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        // RestartLevel() fonksiyonunu animasyonun sonunda çağıracağız.
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}