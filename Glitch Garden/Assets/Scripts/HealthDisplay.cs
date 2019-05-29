using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int playerHP = 10;
    Text playerHPText;


    // Start is called before the first frame update
    void Start()
    {
        playerHPText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        playerHPText.text = playerHP.ToString();
    }

    public void ReducePlayerHP()
    {
        playerHP -= 1;
        UpdateDisplay();

        if (playerHP <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }       
    }
}
