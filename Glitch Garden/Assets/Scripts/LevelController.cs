using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel; // drag the Level Complete Canvas from the Hierarchy into empty field in Inspector
    [SerializeField] float timeToWait = 5f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false); // removed the Level Complete Canvas from the game screen at startup
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
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeToWait);
        GetComponent<LevelLoader>().LoadNextScene();
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
