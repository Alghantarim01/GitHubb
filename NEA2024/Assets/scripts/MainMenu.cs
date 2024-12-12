using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //this allows me to use the unity built in scene manager to swaps between scenes 



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


	public void volumeSlider (float volume)
	{
		
	}




}
