using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed since Slider is a UI element

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen?");
        }
    }

    // saves the volume setting to the master volume key and exits to main menu
    public void SaveAndExit() 
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
    }
}
