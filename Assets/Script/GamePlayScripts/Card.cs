using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public enum Color
{
    Hearts,
    Diamonds,
    Clubs,
    Spades

}
public enum NameOfCard
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jake,
    Queen,
    King

}
public class Card : MonoBehaviour
{
    public Color Color;
    public NameOfCard Name;

    public Card(Color color, NameOfCard name)
    {
        this.Color = color;
        this.Name = name;
    }

}
