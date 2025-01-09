using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardSO currentTheme;

    public void SetTheme(CardSO newTheme) 
    {
        currentTheme = newTheme;
    }

    public CardSO GetTheme() { 
        return currentTheme;
    }
}
