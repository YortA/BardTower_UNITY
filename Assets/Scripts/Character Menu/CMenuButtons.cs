using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMenuButtons : MonoBehaviour
{

    // Keycode
    public KeyCode CMenuKey;

    // Button(s)
    private Button CMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        CMenuButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuButtonInvoke();
    }

    public void MenuButtonInvoke()
    {
        if (Input.GetKeyDown(CMenuKey))
        {
            FadeColor(CMenuButton.colors.pressedColor);
            CMenuButton.onClick.Invoke();
        }
        else if (Input.GetKeyUp(CMenuKey))
        {
            FadeColor(CMenuButton.colors.normalColor);
        }
    }

    // Access fade color parameters
    void FadeColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, CMenuButton.colors.fadeDuration, true, true);
    }
}
