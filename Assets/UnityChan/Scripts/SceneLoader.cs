using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	void LoadPreScene()
	{
		int nextLevel = Application.loadedLevel + 1;
		if( nextLevel <= 1)
			nextLevel = Application.levelCount;

		Application.LoadLevel(nextLevel);
	}

	void LoadNextScene()
	{
		int nextLevel = Application.loadedLevel + 1;
		if( nextLevel >= Application.levelCount)
			nextLevel = 1;

		Application.LoadLevel(nextLevel);

	}
}
