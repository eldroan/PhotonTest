using Constants.Truco.Card;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "TrucoData/Card")]
public class Card : ScriptableObject {
    [SerializeField] public Number number;
    [SerializeField] public Type type;
    [SerializeField] public Sprite image;
	[SerializeField] public Rank rank;
}
