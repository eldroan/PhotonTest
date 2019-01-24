using Constants.Truco;
using Constants.Truco.Card;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataSerializer
{
    public static Deck cards = null;
    private static Dictionary<string, Card> cardCollection = null;


    private static void Initialize()
    {
        if(cardCollection == null)
        {
            cards = Resources.Load<Deck>("TrucoDeck");
            if (cards != null)
            {
                cardCollection = new Dictionary<string, Card>();
                foreach (Card card in cards.deck)
                {
                    cardCollection.Add(card.name, card);
                }
            }
            else
            {
                Debug.Log("No se encontro TrucoDeck en la carpeta Resources");
            }
        }
    }

    public static string Serialize(GameData gamedata)
    {
        if(cardCollection == null)
        {
            Initialize();
        }
        SerializableGameData serializableGD = new SerializableGameData();

        serializableGD.player1Name = gamedata.player1Name;
        serializableGD.player2Name = gamedata.player2Name;
        serializableGD.player1AvatarIndx = gamedata.player1AvatarIndx;
        serializableGD.player2AvatarIndx = gamedata.player2AvatarIndx;
        serializableGD.florIsActive = gamedata.florIsActive;

        serializableGD.matchOnCourse = gamedata.matchOnCourse;
        serializableGD.gameOnCourse = gamedata.gameOnCourse;
        serializableGD.player1Score = gamedata.player1Score;
        serializableGD.player2Score = gamedata.player2Score;
        serializableGD.maxScore = gamedata.maxScore;
        serializableGD.maxTimeToPlay = gamedata.maxTimeToPlay;

        serializableGD.playerFirst = gamedata.playerFirst;
        serializableGD.playerPlay = gamedata.playerPlay;
        serializableGD.playerMustAnswer = gamedata.playerMustAnswer;

        //[Header("My live Hand values for play mode")]
        serializableGD.player1Cards = new string[gamedata.player1Cards.Count];
        for(int i =0; i < serializableGD.player1Cards.Length; i++)
        {
            try
            {
                serializableGD.player1Cards[i] = gamedata.player1Cards[i].name;
            }
            catch(Exception ex)
            {
                serializableGD.player1Cards[i] = String.Empty;
            }
        }

        serializableGD.player1PlayedCards = new string[gamedata.player1PlayedCards.Count];
        for (int i = 0; i < serializableGD.player1PlayedCards.Length; i++)
        {
            try
            {
                serializableGD.player1PlayedCards[i] = gamedata.player1PlayedCards[i].name;
            }
            catch (Exception ex)
            {
                serializableGD.player1PlayedCards[i] = String.Empty;
            }
        }
        serializableGD.player1EnvidoPoints = gamedata.player1EnvidoPoints;
        serializableGD.player1Flor = gamedata.player1Flor;
        serializableGD.player1FlorPoints = gamedata.player1FlorPoints;

        serializableGD.player2Cards = new string[gamedata.player2Cards.Count];
        for (int i = 0; i < serializableGD.player2Cards.Length; i++)
        {
            try
            {
                serializableGD.player2Cards[i] = gamedata.player2Cards[i].name;
            }
            catch (Exception ex)
            {
                serializableGD.player2Cards[i] = String.Empty;
            }
        }
        serializableGD.player2PlayedCards = new string[gamedata.player2PlayedCards.Count];
        for (int i = 0; i < serializableGD.player2PlayedCards.Length; i++)
        {
            try
            {
                serializableGD.player2PlayedCards[i] = gamedata.player2PlayedCards[i].name;
            }
            catch (Exception ex)
            {
                serializableGD.player2PlayedCards[i] = String.Empty;
            }
        }
        serializableGD.player2EnvidoPoints = gamedata.player2EnvidoPoints;
        serializableGD.player2Flor = gamedata.player2Flor;
        serializableGD.player2FlorPoints = gamedata.player2FlorPoints;


        //[Header("Live Hand common values for play mode")]
        serializableGD.round = gamedata.round;
        serializableGD.trucoState = gamedata.trucoState;
        serializableGD.whoCalledLastTruco = gamedata.whoCalledLastTruco;
        serializableGD.envidoState = gamedata.envidoState;
        serializableGD.whoCalledLastEnvido = gamedata.whoCalledLastEnvido;
        serializableGD.envidoWinner = gamedata.envidoWinner;
        serializableGD.envidoWinnedPoints = gamedata.envidoWinnedPoints;
        serializableGD.florState = gamedata.florState;
        serializableGD.whoCalledLastFlor = gamedata.whoCalledLastFlor;
        serializableGD.florWinner = gamedata.florWinner;
        serializableGD.florWinnedPoints = gamedata.florWinnedPoints;
        serializableGD.handWinner = gamedata.handWinner;

        return JsonUtility.ToJson(serializableGD);
    }
    public static GameData DeSerialize(string gamedata)
    {
        if (cardCollection == null)
        {
            Initialize();
        }

        SerializableGameData serializableGD = JsonUtility.FromJson<SerializableGameData>(gamedata);
        GameData gd = ScriptableObject.CreateInstance<GameData>();
        gd.player1Name = serializableGD.player1Name;
        gd.player2Name = serializableGD.player2Name;
        gd.player1AvatarIndx = serializableGD.player1AvatarIndx;
        gd.player2AvatarIndx = serializableGD.player2AvatarIndx;
        gd.florIsActive = serializableGD.florIsActive;

        gd.matchOnCourse = serializableGD.matchOnCourse;
        gd.gameOnCourse = serializableGD.gameOnCourse;
        gd.player1Score = serializableGD.player1Score;
        gd.player2Score = serializableGD.player2Score;
        gd.maxScore = serializableGD.maxScore;
        gd.maxTimeToPlay = serializableGD.maxTimeToPlay;

        gd.playerFirst = serializableGD.playerFirst;
        gd.playerPlay = serializableGD.playerPlay;
        gd.playerMustAnswer = serializableGD.playerMustAnswer;

        gd.player1EnvidoPoints = serializableGD.player1EnvidoPoints;
        gd.player1Flor = serializableGD.player1Flor;
        gd.player1FlorPoints = serializableGD.player1FlorPoints;

        gd.player2EnvidoPoints = serializableGD.player2EnvidoPoints;
        gd.player2Flor = serializableGD.player2Flor;
        gd.player2FlorPoints = serializableGD.player2FlorPoints;

        gd.player1Cards = new List<Card>();
        for (int i = 0; i < serializableGD.player1Cards.Length; i++)
        {
            if(String.Empty.Equals(serializableGD.player1Cards[i]) == false)
            {
                gd.player1Cards.Add(cardCollection[serializableGD.player1Cards[i]]);
            }
            else
            {
                gd.player1Cards.Add(null);
            }
        }

        gd.player1PlayedCards = new List<Card>();
        for (int i = 0; i < serializableGD.player1PlayedCards.Length; i++)
        {
            if (String.Empty.Equals(serializableGD.player1PlayedCards[i]) == false)
            {
                gd.player1PlayedCards.Add(cardCollection[serializableGD.player1PlayedCards[i]]);
            }
            else
            {
                gd.player1PlayedCards.Add(null);
            }
        }

        gd.player2Cards = new List<Card>();
        for (int i = 0; i < serializableGD.player2Cards.Length; i++)
        {
            if (String.Empty.Equals(serializableGD.player2Cards[i]) == false)
            {
                gd.player2Cards.Add(cardCollection[serializableGD.player2Cards[i]]);
            }
            else
            {
                gd.player2Cards.Add(null);
            }
        }

        gd.player2PlayedCards = new List<Card>();
        for (int i = 0; i < serializableGD.player2PlayedCards.Length; i++)
        {
            if (String.Empty.Equals(serializableGD.player2PlayedCards[i]) == false)
            {
                gd.player2PlayedCards.Add(cardCollection[serializableGD.player2PlayedCards[i]]);
            }
            else
            {
                gd.player2PlayedCards.Add(null);
            }
        }

        return gd;
    }

    [System.Serializable]
    private class SerializableGameData
    {
        //Data del player
        public string player1Name;
        public string player2Name;
        public int player1AvatarIndx;
        public int player2AvatarIndx;
        public bool florIsActive;

        //[Header("Live Game values for play mode")]
        public bool matchOnCourse;
        public bool gameOnCourse;
        public int player1Score;
        public int player2Score;
        public int maxScore;
        public float maxTimeToPlay;

        public Player playerFirst;
        public Player playerPlay;
        public Player playerMustAnswer;

        //[Header("My live Hand values for play mode")]
        public string[] player1Cards;
        public string[] player1PlayedCards;
        public int player1EnvidoPoints;
        public bool player1Flor;
        public int player1FlorPoints;

        //[Header("Enemy live Hand values for play mode")]
        public string[] player2Cards;
        public string[] player2PlayedCards;
        public int player2EnvidoPoints;
        public bool player2Flor;
        public int player2FlorPoints;

        //[Header("Live Hand common values for play mode")]
        public int round;
        public TrucoState trucoState;
        public ActionCaller whoCalledLastTruco;
        public EnvidoState envidoState;
        public ActionCaller whoCalledLastEnvido;
        public EnvidoWinner envidoWinner;
        public int envidoWinnedPoints;
        public FlorState florState;
        public ActionCaller whoCalledLastFlor;
        public FlorWinner florWinner;
        public int florWinnedPoints;
        public HandWinner handWinner;

    }
    
}
