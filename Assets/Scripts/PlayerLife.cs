using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private int lifes = 5;
    [SerializeField] private Text vidaText;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void restarVida()
    {
        if (lifes >= 1)
        {
            lifes--;
            vidaText.text = lifes.ToString();
        }
        Die();
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
            StartCoroutine(WaitForDeathFinal());
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
