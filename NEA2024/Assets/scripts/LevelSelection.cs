using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //this allows me to use the unity built in scene manager to swaps between scenes 



public class LevelSelection : MonoBehaviour {

	public void SelectLevel1()// loads my secenes depend on the button clicked 
	{
		SceneManager.LoadScene("Level1Scene");
	}


	public void SelectLevel2()
	{
		SceneManager.LoadScene("Level2Scene");
	}


	public void SelectLevel3()
	{
		SceneManager.LoadScene("Level3Scene");
	}
}
