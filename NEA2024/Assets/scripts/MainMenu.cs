using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //this allows me to use the unity built in scene manager to swaps between scenes 
using TMPro; // allows me to use textmeshpro 


public class MainMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
	private bool isPaused = false;
	public TextMeshPro timer;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) // cheks if game is paused or not 
		{
			if (isPaused)
			{
				PauseGame ();
			}
			else 
			{
				ResumeGame ();
			}
		}
		timer.text = Time.fixedTime.ToString("0.00"); // displays timer 
	}

	public void PauseGame() // pauses the game 
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void ResumeGame() // resumes the game 
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void RestartGame() // allows you to restart the game 
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitLevel()// quits the level and loads the main menu
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
	public void PlayGame()// opens the level selection scene 
	{
		SceneManager.LoadScene("LevelSelectScene");
	}
	public void Options()// opens option menu 
	{
		SceneManager.LoadScene("OptionsScene");
	}
	public void QuitGame()// quits game 
	{
		Application.Quit (); 
	}
	public void GoBack()// allows you to go back to menu 
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void NextLevel()// loads next level
	{
		if (SceneManager.GetActiveScene ().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
	public void ReplayLevel()// replays the level 
	{
		if (SceneManager.GetActiveScene ().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 0);
		}
	}
}
