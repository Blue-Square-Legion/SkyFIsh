using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO _cardDetails;
    [SerializeField] private Material _cardFrontMat, _cardBackMat;
    [SerializeField] private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

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
        _cardFrontMat = _cardDetails.ApplyCardFaceMat();
        _cardBackMat = _cardDetails.ApplyCardBackMat();
        _renderer.materials[0] = _cardFrontMat;
        _renderer.materials[1] = _cardBackMat;
    }
}
