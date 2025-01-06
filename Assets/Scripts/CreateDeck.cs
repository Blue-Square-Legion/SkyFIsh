using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class CreateDeck : MonoBehaviour
{
    public List<Card> Cards;
    public GameObject Card;
    private float cardOffSet;
    private Vector3 lastSpawnedCardPos;

    public List<Card> tempList;

    // Start is called before the first frame update
    void Start()
    {
        cardOffSet = Card.GetComponent<MeshRenderer>().bounds.size.z;
        CreateStandardDeck();
        ShuffleDeck();
    }

    private Card CreateStandardDeck() 
    {
        Debug.Log("Generating Deck");
        for (int i = 1; i < 53; i++)
        {
            GameObject newCard = Instantiate(Card, lastSpawnedCardPos + new Vector3(0, 0, cardOffSet), Quaternion.identity);
            lastSpawnedCardPos = newCard.transform.position;
            Card newCardInfo = newCard.GetComponent<Card>();
            newCard.transform.parent = transform;
            if (i < 14)
            {
                newCardInfo.CreateCard(i, CardSO.Suite.Spade);
            }
            else if (i < 27)
            {
                newCardInfo.CreateCard(i - 13, CardSO.Suite.Club);
            }
            else if (i < 40)
            {
                newCardInfo.CreateCard(i - 26, CardSO.Suite.Diamond);
            }
            else
            {
                newCardInfo.CreateCard(i - 39, CardSO.Suite.Heart);
            }
            Cards.Add(newCardInfo);
        }
        return null;
    }

    public void ShuffleDeck() 
    {
        tempList = new List<Card>(Cards);
        Cards.Clear();
        Card chosenCard, lastChosenCard = null;
        do
        {
            if (tempList.Count > 0)
            {
                int tempNumber = Random.Range(0, tempList.Count - 1);
                chosenCard = tempList[tempNumber];
                Cards.Add(chosenCard);
                tempList.Remove(chosenCard);
                if (lastChosenCard == null)
                {
                    lastChosenCard = chosenCard;
                    chosenCard.gameObject.transform.position = transform.position;
                }
                else
                {
                    chosenCard.gameObject.transform.position = lastChosenCard.gameObject.transform.position + new Vector3(0, 0, cardOffSet);
                    lastChosenCard = chosenCard;
                }
            }
            else if(tempList.Count == 0)
            {
                chosenCard = tempList[0];
                Cards.Add(chosenCard);
                tempList.Remove(chosenCard);
                chosenCard.gameObject.transform.position = lastChosenCard.gameObject.transform.position + new Vector3(0, 0, cardOffSet);
            }
        }
        while(tempList.Count > 0);
    }
}