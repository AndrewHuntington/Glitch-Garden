using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")] // adds tooltip to levelTime field in inspector
    [SerializeField] float levelTime = 10f;
    
    // Update is called once per frame
    void Update()
    {
        // controls the level time slider UI
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        // code below controls what to do after level time is over
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            Debug.Log("Level timer expired!");
        }

    }
}
