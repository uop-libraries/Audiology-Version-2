using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
 
using UnityEngine.SceneManagement;

public class startGame: MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Game");
    }
}