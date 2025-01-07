using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardSO _cardDetails;
    [SerializeField] private Material _cardFrontMat, _cardBackMat;
    [SerializeField] private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
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
        Material[] _materialArray = new Material[2];
        _materialArray[0] = _cardFrontMat;
        _materialArray[1] = _cardBackMat;

        _renderer.materials = _materialArray;
    }
}
