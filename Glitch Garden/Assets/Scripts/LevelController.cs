using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject youWinCanvas; // drag the You Win Canvas from the Hierarchy into empty field in Inspector
    [SerializeField] GameObject youLoseCanvas; // drag the You Lose Canvas from the Hierarchy into empty field in Inspector
    [SerializeField] float timeToWait = 3f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool levelFinishActive = false;

    private void Start()
    {
        youWinCanvas.SetActive(false); // remove the You Win Canvas from the game screen at startup
        youLoseCanvas.SetActive(false); // remove the You Lose Canvas from the game screen at startup
    }

    // called by Awake() in attacker.cs
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    // called by OnDestroy() in attacker.cs
    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        if (levelFinishActive == false)
        {
            youWinCanvas.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(timeToWait);
            GetComponent<LevelLoader>().LoadNextScene();
            
        }
    }

    public void HandleLoseCondition()
    {
        levelFinishActive = true;
        youLoseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // called by if statement in Update() in GameTimer.cs
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
    
}
