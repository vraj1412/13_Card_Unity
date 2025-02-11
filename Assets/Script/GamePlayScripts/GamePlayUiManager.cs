#region SettingPopUP elements
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

    public List<Sprite> Card_Sprite = new List<Sprite>();
    
    public List<Card> cards = new List<Card>();
    public List<GameObject> Card_GameObjects = new List<GameObject>();

    public GameObject Pref_GameObject;

    public List<Card> Card_List1 = new List<Card>();
    public List<Card> Card_List2 = new List<Card>();
    public List<Card> Card_List3 = new List<Card>();

    public Transform Parent1_GameObject;
    public Transform Parent2_GameObject;
    public Transform Parent3_GameObject;

    #endregion

    public GamePlayManager Ref_GamePlayManager;
    public SoundAndMusicManager Ref_SoundAndMusicManager;



    public void Start()
    {
        Ref_SoundAndMusicManager = SoundAndMusicManager.instance;

        SoundSlider.value = StaticData.Sound;
        MusicSlider.value = StaticData.Music;

        SetSoundAndMusicValue();
        Ref_SoundAndMusicManager.PlayMusic(BgMusic_Clip);

        GameStart();
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


    public void GameStart()
    {
        CreatCardList();
        CreatCard_GameObjectList();

    }

    public int GetCardIndex(Card card)
    {
        return (Ref_GamePlayManager.GetColor(card.Color)) + (Ref_GamePlayManager.GetValue(card.Name) - 2);
    }



    public void LoadCard()
    {
        for (int i = 0; i < Card_GameObjects.Count; i++)
        {
            SetCardData(GetCard(Card_GameObjects[i]), cards[i].Color, cards[i].Name);
            LoadSprit(Card_GameObjects[i], GetCard(Card_GameObjects[i]));
            ActiveObject(Card_GameObjects[i]);
        }
    }
    public Card GetCard(GameObject gameObject)
    {
        return gameObject.GetComponent<Card>();

    }
    public void SetCardData(Card card, Color color, Name name)
    {
        card.Name = name;
        card.Color = color;
    }
    public void LoadSprit(GameObject gameObject, Card card)
    {
        gameObject.GetComponent<Image>().sprite = Card_Sprite[GetCardIndex(card)];
    }

    public bool FindEliment(Card card, List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].Color == card.Color && cards[i].Name == card.Name)
                return true;
        }
        return false;
    }
    public void CreatCard(Card card)
    {

        if (!cards.Any())
        {
            cards.Add(card);
        }
        else if (!FindEliment(card, cards))
        {

            cards.Add(card);
            return;
        }
    }

    public void CreatCardList()
    {
        cards.Clear();
        while (cards.Count < 13)
        {
            CreatCard(LoadRendomCard());
        }
    }

    public Card LoadRendomCard()
    {

        Card card = new Card((Color)Random.Range(0, 4), (Name)Random.Range(0, 13));
        return card;

    }

    public Transform SetTrnform(int Count)
    {
        if (Count < 5)
        {
            return Parent1_GameObject;
        }
        else if (Count < 10)
        {
            return Parent2_GameObject;
        }
        else
        {
            return Parent3_GameObject;
        }

    }
    public void CreatCard_GameObjectList()
    {
        Card_GameObjects.Clear();
        while (Card_GameObjects.Count < 13)
        {
            Card_GameObject();
        }
    }

    public void ActiveObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void DeaciveObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public void Card_GameObject()
    {
        GameObject TempGameObject = Instantiate(Pref_GameObject, SetTrnform(Card_GameObjects.Count));
        DeaciveObject(TempGameObject);
        Card_GameObjects.Add(TempGameObject);
    }
    public Card Find_Card(Transform transform, int Index)
    {


        return transform.GetChild(Index).GetComponent<Card>();
    }


    

    #endregion
}





#endregion