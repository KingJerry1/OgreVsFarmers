using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawden() {
        numberOfAttackers++;
    }

    public void AttackerKilled() {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished) {
            Debug.Log("EndTheGame");
        }
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spwanerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spwanerArray) {
            spawner.StopSpawning();
        }
    }
}
