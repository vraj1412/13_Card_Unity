using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameStartTime gameStartTime;
    public GamePlayBtnManager GamePlayBtnManager;
    public GamePlayUiManager GamePlayUiManager;
    public SoundAndMusicManager SoundAndMusicManager;


    public void Start()
    {
        StartCoroutine(gameStartTime.StartTime());
    }



}
