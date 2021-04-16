using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIActions : MonoBehaviour
{

  public void Retry()
  {
    SceneManager.LoadScene("Gameplay");
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void ExitGame()
  {
    Application.Quit();
  }

}
