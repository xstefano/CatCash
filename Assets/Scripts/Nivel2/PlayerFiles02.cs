using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFiles02 : MonoBehaviour
{
    public static Animator anim;
    public int lifes ;
    [SerializeField] private Text vidaText;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        lifes = PlayerPrefs.GetInt("Vidas");
        vidaText.text = lifes.ToString();
        anim = GetComponent<Animator>();
    }

    public void restarVida()
    {
        if (lifes >= 1)
        {
            lifes--;
            vidaText.text = $"x{lifes.ToString()} ";
        }
        Die();
    }
    public void aumentarVida()
    {
        lifes++;
        vidaText.text = $"x{lifes.ToString()} ";

    }

    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetBool("death", true);
        if (lifes > 0)
        {
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            //StartCoroutine(WaitForDeathFinal());
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("death", false);
        anim.SetInteger("state", 0);
    }

    IEnumerator WaitForDeathFinal()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Time.timeScale = 0f;
    }

}