using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static int level = 1;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("Level", level);
        levelText.text = "LEVEL: " + level;
    }

    
}
