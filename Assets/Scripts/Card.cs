using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CardSO _cardDetails;
    [SerializeField] private GameObject _cardFront, _cardBack;
    public void CreateCard(int rank, CardSO.Suite suite) 
    {
        if (_cardDetails.Equals(null)) 
        {
            Debug.Log("CardSO is Null, getting theme from Game Manager");
            _cardDetails = GameObject.Find("GameManager").GetComponent<GameManager>().GetTheme();
        }

        _cardDetails.SetRank(rank);
        _cardDetails.SetSuite(suite);
        gameObject.name = $"{_cardDetails.GetSuite()}_{_cardDetails.GetRank()}";
        _cardFront.GetComponent<SpriteRenderer>().sprite = _cardDetails.ApplyCardFace();
        _cardBack.GetComponent<SpriteRenderer>().sprite = _cardDetails.ApplyCardBack();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
