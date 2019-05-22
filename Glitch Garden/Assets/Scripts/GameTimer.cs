using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")] // adds tooltip to levelTime field in inspector
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;
    
    // Update is called once per frame
    void Update()
    {
        // prevent from unnecessary looping
        if (triggeredLevelFinished) { return; }

        // controls the level time slider UI
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        // code below controls what to do after level time is over
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }

    }
}
