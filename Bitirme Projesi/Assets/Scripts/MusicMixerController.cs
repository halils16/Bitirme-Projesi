using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicMixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject window;
    public GameObject audioPanel;
    public GameObject controlPanel;
    public GameObject aboutMe;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;

    void SetSlider()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            SetSlider();
        }
        else
        {
            SetSlider();
        }
        AudioListener.pause = false;
    }

    public void UpdateMasterVolume()
    {
        mixer.SetFloat("MasterVolume", MasterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }

    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }

    public void UpdateSFXVolume()
    {
        mixer.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            window.SetActive(!window.activeInHierarchy);

            if (window.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
                

        }
    }

    public void PanelAudio()
    {
        audioPanel.SetActive(true);
    }
    public void ClosePanelAudio()
    {
        audioPanel.SetActive(false);
    }

    public void PanelControl()
    {
        controlPanel.SetActive(true);
    }
    public void ClosePanelControl()
    {
        controlPanel.SetActive(false);
    }
    public void AboutMePanel()
    {
        aboutMe.SetActive(true);
    }
    public void CloseAboutMePanel()
    {
        aboutMe.SetActive(false);
    }

}
