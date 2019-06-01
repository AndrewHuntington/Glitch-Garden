using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHP = 3f;
    [SerializeField] int damage = 1;
    float playerHP;
    Text playerHPText;


    // Start is called before the first frame update
    void Start()
    {
        playerHP = baseHP - PlayerPrefsController.GetDifficulty();
        playerHPText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        playerHPText.text = playerHP.ToString();
    }

    public void ReducePlayerHP()
    {
        playerHP -= damage;
        UpdateDisplay();

        if (playerHP <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }       
    }

    public void SetHealth(float hp)
    {
        playerHP = hp;
    }
}
