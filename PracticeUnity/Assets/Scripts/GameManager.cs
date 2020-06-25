using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void EndGame()
    {
      if (!gameHasEnded)
      {
        gameHasEnded = true;
        Invoke("Restart", restartDelay);
      }
    }

    void Restart()
    {
      //First one can choose any level
      //Second restarts level
      //SceneManager.LoadScene("Level1");
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
      completeLevelUI.SetActive(true);
    }
}
