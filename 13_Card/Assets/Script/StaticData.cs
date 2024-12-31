using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData 
{
    #region Sound Get Set Data 
    public static float Sound
    {
        get
        {
            return PlayerPrefs.GetFloat("Sound", 0.0f);
        }
        set
        {
            PlayerPrefs.SetFloat("Sound", value);
            PlayerPrefs.Save();
        }
    }

    public static int MuteSound
    {
        get
        {
            return PlayerPrefs.GetInt("MuteSound", 0);
        }
        set
        {
            PlayerPrefs.SetInt("MuteSound", value);
            PlayerPrefs.Save();

        }
    }
    #endregion

    #region Music Get Set Data 

    public static float Music
    {
        get
        {
            return PlayerPrefs.GetFloat("Music", 0.0f);

        }
        set
        {
            PlayerPrefs.SetFloat("Music", value);
            PlayerPrefs.Save();
        }
    }

    public static int MuteMusic
    {
        get
        {
            return PlayerPrefs.GetInt("MuteMusic", 0);
        }
        set
        {
            PlayerPrefs.SetInt("MuteMusic", value);
            PlayerPrefs.Save();

        }
    }
    #endregion


    public static string GamePlayScene = "GamePlayScene";
    public static string SplashScene = "SplashScene";
}
