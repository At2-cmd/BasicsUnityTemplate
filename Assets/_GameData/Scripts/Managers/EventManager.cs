using Rotatelab.Core;

namespace Rotatelab.Manager
{
	public static class EventManager
	{
    #region Events
		public static GameAction OnLevelStart = new GameAction(nameof(OnLevelStart), ref _onEvenManagerDestroyed);
		public static GameAction OnLevelWin = new GameAction(nameof(OnLevelWin), ref _onEvenManagerDestroyed);
		public static GameAction OnLevelLose = new GameAction(nameof(OnLevelLose), ref _onEvenManagerDestroyed);
		public static GameAction OnLevelDraw = new GameAction(nameof(OnLevelDraw), ref _onEvenManagerDestroyed);
		public static GameAction OnLevelOver = new GameAction(nameof(OnLevelOver), ref _onEvenManagerDestroyed);
		public static GameAction OnLeftClicked = new GameAction(nameof(OnLeftClicked), ref _onEvenManagerDestroyed);

		//TODO: Add events here
	#endregion

	#region Destroy
		private static System.Action _onEvenManagerDestroyed;
		public static void Destroy()
		{
			_onEvenManagerDestroyed?.Invoke();
		}
	#endregion
	}
}


