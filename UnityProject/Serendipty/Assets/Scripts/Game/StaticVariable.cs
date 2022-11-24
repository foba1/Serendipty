using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariable
{
    // Deck
    public static string MyDeck = "";

    // Card Class
    public static readonly int Legendary = 200;
    public static readonly int Normal = 201;

    // Card Price
    public static readonly int LegendaryCardPrice = 200;
    public static readonly int NormalCardPrice = 40;

    // Max & Min Card Count
    public static readonly int MaxLegendaryCardCount = 1;
    public static readonly int MaxNormalCardCount = 3;
    public static readonly int MaxDeckCardCount = 30;
    public static readonly int MinDeckCardCount = 3;

    // Card Property
    public static readonly int Light = 100;
    public static readonly int Dark = 101;
    public static readonly int Fire = 102;
    public static readonly int Water = 103;
    public static readonly int Wood = 104;

    // Card Type
    public static readonly int Creature = 300;
    public static readonly int Spell = 301;

    // Deck
    public static readonly int MaxDeckCount = 5;

    // Legendary Card Index
    public static readonly int[] LegendaryCardIndexArray = new int[5] { 3, 7, 11, 15, 19 };

    // Player Max Health
    public static readonly int PlayerMaxHealth = 600;

    // Winning Result Gold
    public static readonly int WinningResultGold = 20;

    // Card Index
    public static readonly int CardCount = 20;
    public static readonly int Resurrection = 0;
    public static readonly int HolyKnight = 1;
    public static readonly int Skeleton = 4;
}
