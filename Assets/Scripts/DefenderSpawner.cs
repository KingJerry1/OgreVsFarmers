﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;

    private void OnMouseDown() {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 grindPos) {
        var CoinDisplay = FindObjectOfType<CoinDisplay>();
        int defenderCost = defender.GetCoinCost();
        if(CoinDisplay.HaveEnoughtCoins(defenderCost)) {
            SpawnDefender(grindPos);
            CoinDisplay.SpendCoins(defenderCost);
        }
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos) {
        Defender newDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;
    }

}
