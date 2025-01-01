using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    private CardSO _cardDetails;

    private void Awake()
    {
        //_cardDetails = new CardSO();
    }

    public void CreateCard(int rank, CardSO.Suite suite) 
    {
        _cardDetails = ScriptableObject.CreateInstance<CardSO>();
        _cardDetails.SetRank(rank);
        _cardDetails.SetSuite(suite);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
