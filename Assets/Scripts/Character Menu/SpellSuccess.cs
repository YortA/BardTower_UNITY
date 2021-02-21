using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSuccess : MonoBehaviour
{
    private Animator TextFade;
    private Text TextContent;

    public static SpellSuccess _success { get; private set; }

    private void Awake()
    {
        if (_success == null)
        {
            _success = this;
        }
    }

    private void Start()
    {
        TextFade = GetComponent<Animator>();
        TextContent = GetComponent<Text>();
    }
    public void CallFade(char Input)
    {
        if (Input == 'a')
        {
            TextContent.text = "Successful Cast!";
            TextFade.Play("FadeText");
            // Reset our animation
            TextFade.Play("FadeText", -1, 0);
        }
        else if (Input == 'z')
        {
            TextContent.text = "Cancelled Spell";
            TextFade.Play("FadeText");
            // Reset our animation
            TextFade.Play("FadeText", -1, 0);
        }
        else if (Input == 'x')
        {
            TextContent.text = "Failed Cast!";
            TextFade.Play("FadeText");
            // Reset our animation
            TextFade.Play("FadeText", -1, 0);
        }
        else if (Input == 'g')
        {
            TextContent.text = "Spell Cancelled!\nMana Refunded!";
            TextFade.Play("FadeText");
            // Reset our animation
            TextFade.Play("FadeText", -1, 0);
        }

    }
}
