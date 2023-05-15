using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : MonoBehaviour
{
    #region 眉仿包访

    float MaxHealth = 100;
    float currentHealth = 100;
    [SerializeField]
    UnityEngine.UI.Slider HealthSlider;

    #endregion 眉仿包访

    #region 家府

    AudioSource playerAudio;
    [SerializeField]
    AudioClip DeathClip;

    #endregion 家府

    [SerializeField]
    UnityEngine.UI.Image DamageImage;
    Color flashColor = new Color(1f, 0f, 0f, 0.2f);

    bool IsDead = false;
    

    void Start()
    {
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = currentHealth = MaxHealth;
        playerAudio = GetComponent<AudioSource>();


    }

    public void TakeDamage(float Damage)
    {
        if (IsDead)
            return;
        
        DamageImage.color = flashColor;
        currentHealth -= Damage;
        HealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            playerAudio.Play();
        }
    }
    void Death()
    {
        playerAudio.clip = DeathClip;
        playerAudio.Play();
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        IsDead = true;

        GetComponent<PlayerMovement>().enabled = false;
        GetComponentInChildren<PlayerShooting>().enabled = false;
        this.enabled = false;

        //UIManager.GameOver();
    }
    private void Update()
    {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, 5f * Time.deltaTime);        
    }

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
