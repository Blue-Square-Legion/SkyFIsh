using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreateDeck : MonoBehaviour
{
    public static ObjectPool<Card> CardDeck;
    public List<Card> Cards;

    private void Awake()
    {
        CardDeck = new ObjectPool<Card>(CreateStandardDeck, DrawCard, ReturnCardToDeck, DestroyCard, true, 1, 52);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateStandardDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Card CreateStandardDeck() 
    {
        Debug.Log("Generating Deck");
        for (int i = 1; i < 53; i++)
        {
            Card newCard = new();
            if (i < 14)
            {
                newCard.CreateCard(i, CardSO.Suite.Spade);
            }
            else if (i < 27)
            {
                newCard.CreateCard(i - 13, CardSO.Suite.Club);
            }
            else if (i < 40)
            {
                newCard.CreateCard(i - 26, CardSO.Suite.Diamond);
            }
            else
            {
                newCard.CreateCard(i - 39, CardSO.Suite.Heart);
            }
            Cards.Add(newCard);
            CardDeck.Release(newCard);
        }
        return null;
    }

    private void DrawCard(Card card) 
    {
        
    }

    private void ReturnCardToDeck(Card card) 
    {
        
    }
    private void DestroyCard(Card card) 
    {

    }
}