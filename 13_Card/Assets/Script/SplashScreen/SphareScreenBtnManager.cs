using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphareScreenBtnManager : MonoBehaviour
{
    public SphareScreenUiManager Ref_SphareScreenUiManagar;
    public SoundAndMusicManager soundandmusic;

    

    public void Start()
    {
        soundandmusic = SoundAndMusicManager.instance;
    }
    public void Button_Control(string button)
    {
        soundandmusic.PlaySound(soundandmusic.Button_Clip);

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
                Ref_SphareScreenUiManagar.Sound_Slidar();
                break;
            case "Music":
                Ref_SphareScreenUiManagar.Music_Slidar();
                break;
            case "Sound_Mute":
                Ref_SphareScreenUiManagar.Sound_Icon();
                break;
            case "Music_Mute":
                Ref_SphareScreenUiManagar.Music_Icon();
                break;
        }
    }

    public void setting_popup_open()
    {
        Ref_SphareScreenUiManagar.OpenSetting();
    }
    public void setting_popup_close()
    {
        Ref_SphareScreenUiManagar.CloseSetting();
    }
}
