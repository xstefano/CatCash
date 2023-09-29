using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static Animator anim;
    private int lifes = 5;
    [SerializeField] private Text vidaText;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

<<<<<<< HEAD
    public void restarVida()
    {
        if (lifes >= 1)
        {
            lifes--;
            vidaText.text = lifes.ToString();
        }
        Die();
    }
        
=======
    public void restarVida()
    {
        if (lifes >= 1)
        {
            lifes--;
            vidaText.text = lifes.ToString();
        }
        Die();
    }
        
>>>>>>> main
    private void Die()
    {
        deathSoundEffect.Play();
        anim.SetBool("death", true);
<<<<<<< HEAD
        if (lifes > 0)
        {
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            //StartCoroutine(WaitForDeathFinal());
            SceneManager.LoadScene("GameOver");
=======
        if (lifes > 0)
        {
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            StartCoroutine(WaitForDeathFinal());
>>>>>>> main
        }
    }

    IEnumerator WaitForDeathAnimation()
<<<<<<< HEAD
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("death", false);
=======
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("death", false);
>>>>>>> main
        anim.SetInteger("state", 0);
    }

    IEnumerator WaitForDeathFinal()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Time.timeScale = 0f;
    }

}
