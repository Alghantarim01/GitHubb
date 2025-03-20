using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //this allows me to use the unity built in scene manager to swaps between scenes 



public class MainMenu : MonoBehaviour
{
	public GameObject pauseMenuUI;
	private bool isPaused = false;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Y))
		{
			Debug.Log ("key pressed");
			if (isPaused)
			{
				PauseGame ();
			}
			else 
			{
				ResumeGame ();
			}
		}
	}

	public void PauseGame()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void ResumeGame()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitLevel()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
	public void PlayGame()
	{
		SceneManager.LoadScene("LevelSelectScene");
	}



	public void GameControls()
	{

	}


	public void Options()
	{
		SceneManager.LoadScene("OptionsScene");
	}




	public void QuitGame()
	{
		Application.Quit (); 
	}



	public void GoBack()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void NextLevel()
	{
		if (SceneManager.GetActiveScene ().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
	public void ReplayLevel()
	{
		if (SceneManager.GetActiveScene ().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 0);
		}
	}


	public void volumeSlider (float volume)
	{
		
	}




}
