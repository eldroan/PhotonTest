using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName ="TrucoData/Deck")]
public class Deck : ScriptableObject
{
    [SerializeField] public List<Card> deck;
    
}
