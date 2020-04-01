using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool haveEnoughStars(int amount)
    {
        if(amount <= stars)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateDisplay();
    }

    public void spendStars(int starsToSpend)
    {
        if (stars >= starsToSpend)
        {
            stars -= starsToSpend;
            UpdateDisplay();
        }
    }

}
