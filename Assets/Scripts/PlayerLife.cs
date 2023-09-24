using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private int lifes = 5;
    [SerializeField] private Text vidaText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Trap"))
    //    {
    //        Die();
    //    }
    //}
    public void restarVida()
    {
        if (lifes>=1)
        {
            lifes--;
            vidaText.text = lifes.ToString();
        }
        
    }
    private void Die()
    {
        anim.SetTrigger("death");
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Time.timeScale = 0f;
    }
}
