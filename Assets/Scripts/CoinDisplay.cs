﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    Text coinText;

    void Start()
    {
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        coinText.text = coins.ToString();
    }

    public bool HaveEnoughtCoins(int amount) {
        return coins >= amount;
    }

    public void AddCoins(int amount) {
        coins += amount;
        UpdateDisplay();
    }

    public void SpendCoins(int amount) {
        if (coins >= amount) {
            coins -= amount;
            UpdateDisplay();
        }
    }

    void Update()
    {
        
    }
}
