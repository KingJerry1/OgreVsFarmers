using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in secounds")]
    [SerializeField] float levelTime = 30f;
    bool triggeredLevelFinished = false;

    private void Update() {
        if(triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished) {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
