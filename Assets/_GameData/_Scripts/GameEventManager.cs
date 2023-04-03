using System;
using UnityEngine;

namespace _GameData._Scripts._Managers
{
    public class GameEventManager : MonoBehaviour
    {
        public static GameEventManager Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
        }

        public Action OnMouseReleased;
        public void RaiseMouseReleased() => OnMouseReleased?.Invoke();

        public Action OnFirstTapOccured;
        public void RaiseFirstTapOccured() => OnFirstTapOccured?.Invoke();

        public Action OnSunnyZoneEntered;
        public void RaiseSunnyZoneEntered() => OnSunnyZoneEntered?.Invoke();

        public Action OnSunnyZoneExited;
        public void RaiseSunnyZoneExited() => OnSunnyZoneExited?.Invoke();

        public Action OnTimerFinished;
        public void RaiseTimerFinished() => OnTimerFinished?.Invoke();

        public Action<bool> OnBiteOccured;
        public void RaiseBiteOccured(bool isCivil) => OnBiteOccured?.Invoke( isCivil);

        public Action OnPlayerDied;
        public void RaisePlayerDied() => OnPlayerDied?.Invoke();

        public Action OnDamageTaken;
        public void RaiseDamageTaken() => OnDamageTaken?.Invoke();

        public Action OnLevelEnded;
        public void RaiseLevelEnded() => OnLevelEnded?.Invoke();
        
        public Action OnOverlapAreaEmpty;
        public void RaiseOverlapAreaEmpty() => OnOverlapAreaEmpty?.Invoke();

        public event Action<Vector3,int> OnPointCollected;
        public void RaisePointCollected(Vector3 wordPos,int pointValue) => OnPointCollected?.Invoke(wordPos,pointValue);

        public event Action OnStartGameCinematic;
        public void RaiseStartGameCinematic() => OnStartGameCinematic?.Invoke();
    }
}

