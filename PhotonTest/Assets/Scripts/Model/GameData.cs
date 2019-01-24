using System.Collections.Generic;
using UnityEngine;
using Constants.Truco;

[CreateAssetMenu(fileName = "New GameData", menuName = "TrucoData/GameData")]
public class GameData : ScriptableObject
{
	[Header("Player's Data")]
	public string player1Name;
	public string player2Name;
	public int player1AvatarIndx;
	public int player2AvatarIndx;
	public bool florIsActive;

	[Header("Live Game values for play mode")]
	public bool matchOnCourse;
	public bool gameOnCourse;
    public int player1Score;
    public int player2Score;
	public int maxScore;
	public float maxTimeToPlay;

	public Player playerFirst;
    public Player playerPlay;
	public Player playerMustAnswer;

	[Header("My live Hand values for play mode")]
    public List<Card> player1Cards;
    public List<Card> player1PlayedCards;
	public int player1EnvidoPoints;
	public bool player1Flor;
	public int player1FlorPoints;
	
    [Header("Enemy live Hand values for play mode")]
    public List<Card> player2Cards;
    public List<Card> player2PlayedCards;
	public int player2EnvidoPoints;
	public bool player2Flor;
	public int player2FlorPoints;

	[Header("Live Hand common values for play mode")]
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

    [SerializeField] Card enemyCardBack;
	[SerializeField] Deck trucoDeck;

	    public void MatchInitialization()
	{
		player1Score = 0;
		player2Score = 0;
		matchOnCourse = true;
		ResetHand();
	}

	public void ResetHand()
	{
		if (player1Score < maxScore && player2Score < maxScore)
		{
			matchOnCourse = true;
		}

		// Clean game states
		gameOnCourse = true;
		round = 1;
		trucoState = TrucoState.NADA;
		whoCalledLastTruco = ActionCaller.NO_ONE;
		envidoState = EnvidoState.NADA;
		whoCalledLastEnvido = ActionCaller.NO_ONE;
		envidoWinnedPoints = 0;
		florState = FlorState.NADA;
		whoCalledLastFlor = ActionCaller.NO_ONE;
		envidoWinner = EnvidoWinner.NO_ONE;
		florWinner = FlorWinner.NO_ONE;
		handWinner = HandWinner.NO_ONE;
		florWinnedPoints = 0;
		player1EnvidoPoints = 0;
		player2EnvidoPoints = 0;
		player1Flor = false;
		player2Flor = false;
		player1FlorPoints = 0;
		player2FlorPoints = 0;

		// Clean cards
		player1Cards.Clear();
		player1PlayedCards.Clear();
		player2Cards.Clear();
		player2PlayedCards.Clear();
		
		// Reset values
		if (playerFirst == Player.PLAYER_1)
		{
			playerFirst = Player.PLAYER_2;
			playerPlay = Player.PLAYER_2;
		}
		else
		{
			playerFirst = Player.PLAYER_1;
			playerPlay = Player.PLAYER_1;
		}
		
		playerMustAnswer = Player.NO_ONE;

		// Shuffle the cards
		List<int> randomIndx = new List<int>();
		int indx;
		bool cloneIndx = false;

		//while (randomIndx.Count < 6)
		//{
		//	indx = Random.Range(0, trucoDeck.deck.Count - 1);
		//	try
		//	{
		//		randomIndx.Single(x => x == indx);
		//	}
		//	catch (System.Exception)
		//	{
		//		randomIndx.Insert(randomIndx.Count, indx);
		//	}
		//}

		while (randomIndx.Count < 6)
		{
			indx = Random.Range(0, trucoDeck.deck.Count - 1);
			cloneIndx = false;
			for (int i=0; i < randomIndx.Count; i++)
			{
				if (randomIndx[i] == indx)
				{
					cloneIndx = true;
				}
			}

			if (!cloneIndx)
			{
				randomIndx.Add(indx);
			}
		}

		if (playerFirst == Player.PLAYER_1)
		{
			player1Cards.Add(trucoDeck.deck[randomIndx[0]]);
			player1Cards.Add(trucoDeck.deck[randomIndx[2]]);
			player1Cards.Add(trucoDeck.deck[randomIndx[4]]);

			player2Cards.Add(trucoDeck.deck[randomIndx[1]]);
			player2Cards.Add(trucoDeck.deck[randomIndx[3]]);
			player2Cards.Add(trucoDeck.deck[randomIndx[5]]);
		}
		else
		{
			player1Cards.Add(trucoDeck.deck[randomIndx[1]]);
			player1Cards.Add(trucoDeck.deck[randomIndx[3]]);
			player1Cards.Add(trucoDeck.deck[randomIndx[5]]);

			player2Cards.Add(trucoDeck.deck[randomIndx[0]]);
			player2Cards.Add(trucoDeck.deck[randomIndx[2]]);
			player2Cards.Add(trucoDeck.deck[randomIndx[4]]);
		}
	}

	public void ResetHandFlorTest1()
	{
		if (player1Score < maxScore && player2Score < maxScore)
		{
			matchOnCourse = true;
		}

		// Clean game states
		gameOnCourse = true;
		round = 1;
		trucoState = TrucoState.NADA;
		whoCalledLastTruco = ActionCaller.NO_ONE;
		envidoState = EnvidoState.NADA;
		whoCalledLastEnvido = ActionCaller.NO_ONE;
		envidoWinnedPoints = 0;
		florState = FlorState.NADA;
		whoCalledLastFlor = ActionCaller.NO_ONE;
		envidoWinner = EnvidoWinner.NO_ONE;
		florWinner = FlorWinner.NO_ONE;
		handWinner = HandWinner.NO_ONE;
		florWinnedPoints = 0;
		player1EnvidoPoints = 0;
		player2EnvidoPoints = 0;
		player1Flor = false;
		player2Flor = false;
		player1FlorPoints = 0;
		player2FlorPoints = 0;

		// Clean cards
		player1Cards.Clear();
		player1PlayedCards.Clear();
		player2Cards.Clear();
		player2PlayedCards.Clear();
		
		// Reset values
		if (playerFirst == Player.PLAYER_1)
		{
			playerFirst = Player.PLAYER_2;
			playerPlay = Player.PLAYER_2;
		}
		else
		{
			playerFirst = Player.PLAYER_1;
			playerPlay = Player.PLAYER_1;
		}
		
		playerMustAnswer = Player.NO_ONE;

		// Shuffle the cards
		List<int> randomIndx = new List<int>();
		int indx;
		bool cloneIndx = false;

		while (randomIndx.Count < 6)
		{
			indx = Random.Range(0, trucoDeck.deck.Count - 1);
			cloneIndx = false;
			for (int i=0; i < randomIndx.Count; i++)
			{
				if (randomIndx[i] == indx)
				{
					cloneIndx = true;
				}
			}

			if (!cloneIndx)
			{
				randomIndx.Add(indx);
			}
		}

		if (playerFirst == Player.PLAYER_1)
		{
			player1Cards.Add(trucoDeck.deck[12]);
			player1Cards.Add(trucoDeck.deck[16]);
			player1Cards.Add(trucoDeck.deck[20]);

			player2Cards.Add(trucoDeck.deck[0]);
			player2Cards.Add(trucoDeck.deck[1]);
			player2Cards.Add(trucoDeck.deck[2]);
		}
		else
		{
			player1Cards.Add(trucoDeck.deck[11]);
			player1Cards.Add(trucoDeck.deck[15]);
			player1Cards.Add(trucoDeck.deck[19]);

			player2Cards.Add(trucoDeck.deck[0]);
			player2Cards.Add(trucoDeck.deck[1]);
			player2Cards.Add(trucoDeck.deck[2]);
		}
	}

	public void ResetHandFlorTest2()
	{
		if (player1Score < maxScore && player2Score < maxScore)
		{
			matchOnCourse = true;
		}

		// Clean game states
		gameOnCourse = true;
		round = 1;
		trucoState = TrucoState.NADA;
		whoCalledLastTruco = ActionCaller.NO_ONE;
		envidoState = EnvidoState.NADA;
		whoCalledLastEnvido = ActionCaller.NO_ONE;
		envidoWinnedPoints = 0;
		florState = FlorState.NADA;
		whoCalledLastFlor = ActionCaller.NO_ONE;
		envidoWinner = EnvidoWinner.NO_ONE;
		florWinner = FlorWinner.NO_ONE;
		handWinner = HandWinner.NO_ONE;
		florWinnedPoints = 0;
		player1EnvidoPoints = 0;
		player2EnvidoPoints = 0;
		player1Flor = false;
		player2Flor = false;
		player1FlorPoints = 0;
		player2FlorPoints = 0;

		// Clean cards
		player1Cards.Clear();
		player1PlayedCards.Clear();
		player2Cards.Clear();
		player2PlayedCards.Clear();
		
		// Reset values
		if (playerFirst == Player.PLAYER_1)
		{
			playerFirst = Player.PLAYER_2;
			playerPlay = Player.PLAYER_2;
		}
		else
		{
			playerFirst = Player.PLAYER_1;
			playerPlay = Player.PLAYER_1;
		}
		
		playerMustAnswer = Player.NO_ONE;

		// Shuffle the cards
		List<int> randomIndx = new List<int>();
		int indx;
		bool cloneIndx = false;

		while (randomIndx.Count < 6)
		{
			indx = Random.Range(0, trucoDeck.deck.Count - 1);
			cloneIndx = false;
			for (int i=0; i < randomIndx.Count; i++)
			{
				if (randomIndx[i] == indx)
				{
					cloneIndx = true;
				}
			}

			if (!cloneIndx)
			{
				randomIndx.Add(indx);
			}
		}

		if (playerFirst == Player.PLAYER_1)
		{
			player1Cards.Add(trucoDeck.deck[12]);
			player1Cards.Add(trucoDeck.deck[16]);
			player1Cards.Add(trucoDeck.deck[20]);

			player2Cards.Add(trucoDeck.deck[11]);
			player2Cards.Add(trucoDeck.deck[15]);
			player2Cards.Add(trucoDeck.deck[19]);
		}
		else
		{
			player1Cards.Add(trucoDeck.deck[11]);
			player1Cards.Add(trucoDeck.deck[15]);
			player1Cards.Add(trucoDeck.deck[19]);

			player2Cards.Add(trucoDeck.deck[12]);
			player2Cards.Add(trucoDeck.deck[16]);
			player2Cards.Add(trucoDeck.deck[20]);
		}
	}
}