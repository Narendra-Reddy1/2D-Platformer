using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIManager : MonoBehaviour
{
    public static LSUIManager lsUIManagerInstance;



    private float maxAlphaValue;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool shouldFadeFromBlack, shouldFadeToBlack;


    [SerializeField] protected Image fadeScreen;


    private void Awake()
    {
        lsUIManagerInstance = this;
        
    }
    private void Start()
    {
        FadeFromBlack();
    }

    private void Update()
    {
        FadeTheScreen();
    }


     void FadeTheScreen()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, maxAlphaValue, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, maxAlphaValue, fadeSpeed *Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        maxAlphaValue = 1.0f;
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;

    }
    public void FadeFromBlack()
    {
        maxAlphaValue = 0f;
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }


}















/*public class FadeScreen:LSUIManager
{
    public static FadeScreen fadeScreenInstance;

    private float maxAlphaValue;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private bool shouldFadeFromBlack, shouldFadeToBlack;



    private void Awake()
    {
        fadeScreenInstance = this;
        fadeScreen = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
      *//*  if (FadeScreen.fadeScreenInstance != null)
        {
            Debug.Log("True From LSUIManager");
        }
        else Debug.Log("False from LSUIManager");*//*

        FadeScreen.fadeScreenInstance.FadeToBlack();
    }

    void Update()
    {
        FadeScreen.fadeScreenInstance.FadeTheScreen();
    }
    public void FadeTheScreen()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, maxAlphaValue, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == maxAlphaValue)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, maxAlphaValue, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == maxAlphaValue)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        maxAlphaValue = 1.0f;
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;

    }
    public void FadeFromBlack()
    {
        maxAlphaValue = 0f;
        shouldFadeFromBlack = true;
        shouldFadeFromBlack = false;
    }
}
*/