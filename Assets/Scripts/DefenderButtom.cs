using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtom : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButtom>();
        foreach(DefenderButtom button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(67, 67, 67, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

}
