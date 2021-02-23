using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    int block = 3;
    int difficulty = 1;

    string key = "dif";

    private void Start()
    {
        if(PlayerPrefs.HasKey(key))
            difficulty = PlayerPrefs.GetInt(key);

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyCn>().SetDifficulty(difficulty);
        GameObject.Find("Score").GetComponent<Text>().text = Convert.ToString(difficulty);
    }

    public void BlockDeath()
    {
        if(block == 1)
        {
            difficulty++;
            PlayerPrefs.SetInt(key, difficulty);

            SceneManager.LoadScene(1);
        }
        else
        {
            block--;
        }
    }
}
