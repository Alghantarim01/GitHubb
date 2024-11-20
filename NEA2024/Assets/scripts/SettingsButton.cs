using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 



public class MainMenu : MonoBehaviour
{


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


}
