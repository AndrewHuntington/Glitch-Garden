using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //needed for Text class

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text startText;

    // Start is called before the first frame update
    void Start()
    {
        startText = GetComponent<Text>();
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
        
    }

}
