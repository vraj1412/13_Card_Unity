using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayBtnManager : MonoBehaviour
{
    public GamePlayUiManager GamePlayUiManager;
    public SoundAndMusicManager SoundAndMusicManager;
    public void Start()
    {
        SoundAndMusicManager = SoundAndMusicManager.instance;
    }
    public void Button_Control(string button)
    {
        SoundAndMusicManager.PlaySound(GamePlayUiManager.Button_Clip);

        switch (button)
        {
            case "start":

                SceneManager.LoadSceneAsync(StaticData.GamePlayScene);
                break;
            case "Open_Setting":
                setting_popup_open();
                break;
            case "Close_Setting":
                setting_popup_close();
                break;
            case "Sound":
                GamePlayUiManager.Sound_Slidar();
                break;
            case "Music":
                GamePlayUiManager.Music_Slidar();
                break;
            case "Sound_Mute":
                GamePlayUiManager.Sound_Icon();
                break;
            case "Music_Mute":
                GamePlayUiManager.Music_Icon();
                break;
        }
    }

    public void setting_popup_open()
    {
        GamePlayUiManager.OpenSetting();
    }
    public void setting_popup_close()
    {
        GamePlayUiManager.CloseSetting();
    }
}


