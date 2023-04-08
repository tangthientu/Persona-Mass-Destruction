using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider volumeSlider;
    public AudioSource shuffleTheme;
    public AudioSource levelTheme;
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }    
        else
        {
            Load();
        }

    }
     void Update()
    {
        if(shuffleTheme.isPlaying)
        {
            levelTheme.Pause();
        }
        else
        {
            levelTheme.UnPause();
        }
    }

    // Update is called once per frame
    public void changevolume()
    {
        AudioListener.volume=volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",volumeSlider.value);
    }
}
