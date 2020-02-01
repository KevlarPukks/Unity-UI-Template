using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager manager;
    [Required]public UIProperties uIProperties; 
    public UnityEvent onTransitionStart;

    [Title("Screen states")]
    public ScreenState splash;
    public ScreenState main;
    public ScreenState settings;
    public ScreenState inGame;
    public ScreenState GameOver;
  
    public Image transition;
    ScreenState currentScreenState;

    private void Awake()
    {
        if (manager == null) manager = this;
    }

    private void Start()
    {
        splash.screen.SetActive(true);
        
        currentScreenState = splash;
        main.screen.SetActive(false);
         settings.screen.SetActive(false);
        inGame.screen.SetActive(false);
        GameOver.screen.SetActive(false);
        StartCoroutine(SplashScreenChange());
    }
    private void Update()
    {
        //if (Input.anyKey) StartCoroutine(ChangeScreen(splash));

    }
    IEnumerator SplashScreenChange()
    {
        splash.onTransitionStart.Invoke();
        transition.raycastTarget = true;
        transition.color = Color.black;
       Tween fadeTween= transition.DOFade(0, uIProperties.CameraFadeTime);
        yield return fadeTween.WaitForCompletion(); 
        splash.onTransitionComplete.Invoke();
        yield return new WaitForSeconds(uIProperties.SplashScreenFadeTime);
        Tween fadeTween2 = transition.DOFade(1, uIProperties.CameraFadeTime);
        main.onTransitionStart.Invoke();
        yield return fadeTween2.WaitForCompletion();
        splash.screen.SetActive(false);
        main.screen.SetActive(true);
        fadeTween = transition.DOFade(0, uIProperties.CameraFadeTime);
        yield return fadeTween.WaitForCompletion();
        currentScreenState = main;
        transition.raycastTarget = false;
       main.onTransitionComplete.Invoke();
    }
    public IEnumerator ChangeScreen(ScreenState newScreen)
    {
        var settingscreen = (currentScreenState == settings);
      onTransitionStart.Invoke();
       if(!settingscreen)  newScreen.onTransitionStart.Invoke();
        transition.raycastTarget = true;
        Tween fadeTween2 = transition.DOFade(1, uIProperties.CameraFadeTime);
        yield return fadeTween2.WaitForCompletion();
        transition.DOFade(1, uIProperties.CameraFadeTime);
        currentScreenState.screen.SetActive(false);
        newScreen.screen.SetActive(true);
       
       
       fadeTween2 = transition.DOFade(0, uIProperties.CameraFadeTime);
        yield return fadeTween2.WaitForCompletion();
        transition.raycastTarget = false;
        currentScreenState = newScreen;
        if (!settingscreen) currentScreenState.onTransitionComplete.Invoke();
    }
    public void SettingsScreen()
    {
        StartCoroutine(ChangeScreen(settings));
    }
    public void MainMenuScreen()
    {
        StartCoroutine(ChangeScreen(main));
    }
    public void InGameScreen()
    {
        StartCoroutine(ChangeScreen(inGame));
    }
    public void GameOverScreen()
    {
        StartCoroutine(ChangeScreen(GameOver));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
