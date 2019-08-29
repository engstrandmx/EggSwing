﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class mainMenuHandler : MonoBehaviour
{
    FMOD.Studio.EventInstance soundMenuMusic;
    FMOD.Studio.EventInstance soundUIClick;
    FMOD.Studio.EventInstance soundUIStart;

    PlayerData data;

    void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }

    void Start()
    {
        soundMenuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/MenuMusic");

        menuMusicPlayerHandler.Instance.checkStarted();

        soundUIClick = FMODUnity.RuntimeManager.CreateInstance("event:/Ui/Button_klick");
        soundUIStart = FMODUnity.RuntimeManager.CreateInstance("event:/Ui/Button_Start");
    }
    
    void Update()
    {
        
    }

    public void ClickOptions()
    {
        soundUIClick.start();
        SceneManager.LoadScene("OptionsScene");
    }

    public void ClickPlay()
    {
        soundMenuMusic.setParameterValue("End", 1);
        soundUIClick.start();
        if (data.seenControls) SceneManager.LoadScene("MenuScene");
        else SceneManager.LoadScene("ControlsScene");

    }

    public void VisitDiscord()
    {
        AnalyticsEvent.Custom("clicked_discord");
        Application.OpenURL("https://discord.gg/3bAe6GC");
    }

    public void VisitSunscale()
    {
        AnalyticsEvent.Custom("clicked_sunscale");
        Application.OpenURL("http://www.sunscalestudios.com/");
    }

    public void QuitGame()
    {
        soundMenuMusic.setParameterValue("End", 1);
        soundUIClick.start();
        Application.Quit();
    }
}
