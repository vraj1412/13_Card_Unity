
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayUiManager : MonoBehaviour
{
    #region Sound And Music
    [Header("SettingPopUp")]
    public GameObject SettingPopUp;
    [Space]
    [Header("Slider")]
    public Slider SoundSlider;
    public Slider MusicSlider;
    [Space]
    [Header("SoundAndMusic MuteParent")]
    public Image SoundImage;
    public Image MusicImage;
    [Space]
    [Header("SoundAndMusic ImageSprite")]
    public Sprite SoundSprite;
    public Sprite MusicSprite;
    public Sprite MuteSoundSprite;
    public Sprite MuteMusicSprite;

    [Space]
    [Header("SoundAndMusic Clip")]
    public AudioClip Button_Clip;
    public AudioClip BgMusic_Clip;
    #endregion
    [Space]
    [Space]
    #region  Game element
    public List<Card> ListOFCards = new List<Card>(); 
    

    #endregion

    public GamePlayManager Ref_GamePlayManager;
    public SoundAndMusicManager Ref_SoundAndMusicManager;
    public Card Ref_card;



    public void Start()
    {
        Ref_SoundAndMusicManager = SoundAndMusicManager.instance;

        SoundSlider.value = StaticData.Sound;
        MusicSlider.value = StaticData.Music;

        SetSoundAndMusicValue();
        Ref_SoundAndMusicManager.PlayMusic(BgMusic_Clip);

        
    }

    #region SettingPopUP Open Close
    public void OpenSetting()
    {
        SettingPopUp.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingPopUp.SetActive(false);
    }

    #endregion

    #region Sound And Music Function
    public void Sound_Slidar()
    {
        StaticData.Sound = SoundSlider.value;

        Ref_SoundAndMusicManager.SetSound_Volume(SoundSlider.value);
        if (StaticData.Sound == 0)

        {

            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }
    }

    public void Music_Slidar()
    {
        StaticData.Music = MusicSlider.value;
        Ref_SoundAndMusicManager.SetMusic_Volume(MusicSlider.value);

        if (StaticData.Music == 0)
        {

            MusicMute(true);
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Music_Icon()
    {
        if (StaticData.MuteMusic == 0)
        {
            MusicMute(true);
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Sound_Icon()
    {
        if (StaticData.MuteSound == 0)
        {
            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }

    }

    public void SoundMute(bool mute)
    {

        if (mute)
        {
            StaticData.MuteSound = 1;
            SoundImage.sprite = MuteSoundSprite;
            Ref_SoundAndMusicManager.SoundMute(true);
            SoundSlider.value = 0;
        }
        else
        {
            StaticData.MuteSound = 0;
            SoundImage.sprite = SoundSprite;
            Ref_SoundAndMusicManager.SoundMute(false);
        }
    }

    public void MusicMute(bool mute)
    {

        if (mute)
        {

            StaticData.MuteMusic = 1;
            MusicImage.sprite = MuteMusicSprite;
            Ref_SoundAndMusicManager.MuiscMute(true);
            MusicSlider.value = 0;

        }
        else
        {

            StaticData.MuteMusic = 0;
            MusicImage.sprite = MusicSprite;
            Ref_SoundAndMusicManager.MuiscMute(false);

        }
    }

    public void SetSoundAndMusicValue()
    {

        SoundMute(StaticData.MuteSound != 0);
        MusicMute(StaticData.MuteMusic != 0);


    }
    #endregion

    #region Game Scripting


    public void CreateCard(Card card)
    {
        if (!ListOFCards.Any())
        {
            ListOFCards.Add(card);
        }
        else if (!FindEliment(card, ListOFCards)){

            ListOFCards.Add(card);
            return;
        
        }
        
    }

    public bool FindEliment(Card card,List<Card> ListOFCards)
    {
        for (int i = 0; i < ListOFCards.Count; i++)
        {
            if (ListOFCards[i].Color == card.Color && ListOFCards[i].Name == card.Name)

                return true;
        
        }    
        return false;   
    }

    public Card LoadCard()
    {
        Card card = new Card((Color)Random.Range(0, 4), (Name)Random.Range(0, 13));
        return card;
    }

    public void CreateCardList()
    {
        ListOFCards.Clear();
        if(ListOFCards.Count < 13)
        {
            CreateCard(LoadCard());
        }
    }



    

    #endregion
}





