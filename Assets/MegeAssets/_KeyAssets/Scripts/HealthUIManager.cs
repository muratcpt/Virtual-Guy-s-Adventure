using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI elemanlarını kullanmak için bu satır gerekli!

public class HealthUIManager : MonoBehaviour
{
    // Inspector'dan Unity içinden atayacağımız kalp resimleri
    public Image[] hearts;

    // Bu fonksiyon, mevcut cana göre kalp resimlerini açıp kapatacak
    public void UpdateHealthUI(int currentHealth)
    {
        // Tüm kalpleri döngüye al
        for (int i = 0; i < hearts.Length; i++)
        {
            // Eğer döngüdeki kalp sırası, mevcut candan küçükse...
            if (i < currentHealth)
            {
                // Kalbi göster
                hearts[i].enabled = true;
            }
            else
            {
                // Değilse, kalbi gizle
                hearts[i].enabled = false;
            }
        }
    }
}