using Rotatelab.Helper;
using UnityEngine;
/*using ElephantSDK;*/

namespace Rotatelab.Manager
{
	public class GameManager : MonoBehaviour
	{
		private const string PLAYER_LEVEL = "PlayerLevel";
		public static int Level => PlayerPrefs.GetInt(PLAYER_LEVEL);

		private void OnDestroy()
		{
			EventManager.Destroy();
		}

		private void Awake()
		{
			Init();
			SignUpGameEvents();
		}

		private void Init()
		{
			/*Elephant.LevelStarted(Level);*/
			EventManager.OnLevelStart.Raise();
		}

		private void SignUpGameEvents()
		{
			EventManager.OnLevelWin += OnLevelWinHandler;
			EventManager.OnLevelDraw += OnLevelDrawHandler;
			EventManager.OnLevelLose += OnLevelLoseHandler;
		}

		private void OnLevelDrawHandler()
		{
			RaiseOnLevelOver();
			/*Elephant.LevelCompleted(Level);*/
		}

		private void OnLevelLoseHandler()
		{
			RaiseOnLevelOver();
			/*Elephant.LevelFailed(Level);*/
		}

		private void OnLevelWinHandler()
		{
			RaiseOnLevelOver();
			/*Elephant.LevelCompleted(Level);*/
		}

		private void RaiseOnLevelOver()
		{
			EventManager.OnLevelOver.Raise();
			OnLevelOverHandler();
		}
		
		private void OnLevelOverHandler()
		{
			
		}
#if UNITY_EDITOR		
		[ContextMenu("Show Event Log")]
		public void ShowEventLog()
		{
			EventHelper.ShowEventLog();
		}
#endif			
	}
}