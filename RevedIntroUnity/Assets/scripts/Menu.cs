using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool inMenu;


    public GameObject CanvasMunu, CanvasTitle;

    public Slider DelaySlider;
    public Text SliderText;
    public float DelayTime;


    public Slider SliderUserSpawnAgain;
    public int SliderAllowAgain;


    public Slider SliderMusic;
    public int MusicOn;
    public GameObject Music;

    // Start is called before the first frame update
    void Start()
    {
        inMenu = false;

        DelayTime = PlayerPrefs.GetFloat("DelayTime", 1);
        DelaySlider.value = DelayTime;
        SliderText.text = Mathf.Round(DelayTime)+ " sec";


        SliderAllowAgain = PlayerPrefs.GetInt("AllowSpawnAgain", 0);
        SliderUserSpawnAgain.value = SliderAllowAgain;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOffMenu();
        }
    }

    private void OnOffMenu()
    {

        if (inMenu)
        {
            Time.timeScale = 1;
            CanvasTitle.SetActive(true);
            CanvasMunu.SetActive(false);

            inMenu = false;
        }
        else
        {
            Time.timeScale = 0;
            CanvasTitle.SetActive(false);
            CanvasMunu.SetActive(true);

            inMenu = true;
        }

    }


    public void Exit()
    {
        Application.Quit();
        
    }

    public void SaveSlider()
    {
        DelayTime = DelaySlider.value;
        SliderText.text = Mathf.Round(DelayTime)+ " sec";
        PlayerPrefs.SetFloat("DelayTime", DelayTime);
    }

    public void ChangeOnSliderAgein()
    {
        SliderAllowAgain = Mathf.RoundToInt(SliderUserSpawnAgain.value);
        PlayerPrefs.SetInt("AllowSpawnAgain", SliderAllowAgain);
    }

    public void SliderButtonPressed()
    {
        if (SliderUserSpawnAgain.value == 1)
        {
            SliderUserSpawnAgain.value= 0.0f;
            SliderAllowAgain = Mathf.RoundToInt(SliderUserSpawnAgain.value);
            PlayerPrefs.SetInt("AllowSpawnAgain", SliderAllowAgain);
        }
        else
        {
            SliderUserSpawnAgain.value= 1.0f;
            SliderAllowAgain = Mathf.RoundToInt(SliderUserSpawnAgain.value);
            PlayerPrefs.SetInt("AllowSpawnAgain", SliderAllowAgain);
        }
    }
    
    
    
    

    public void SliderButtonPressedMusic()
    {
        if (SliderMusic.value == 0)
        {
            SliderMusic.value= 1.0f;
            Music.SetActive(true);
        }
        else
        {
            SliderMusic.value= 0.0f;
            Music.SetActive(false);
        }
    }
}
