using CrazyGames;
using UnityEngine;
using UnityEngine.Events;

namespace CrazyGamesUtils.CrazySDKUtils
{
    public class CrazyGamesAdBreak : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onAdBreakCompleted;
        public UnityEvent OnAdBreakCompleted => _onAdBreakCompleted;
        
        [SerializeField] private UnityEvent _onAdBreakError;
        public UnityEvent OnAdBreakError => _onAdBreakError;
        
        [SerializeField] private UnityEvent _onAdBreakRewardedCompleted;
        public UnityEvent OnAdBreakRewardedCompleted => _onAdBreakRewardedCompleted;
        
        [SerializeField] private UnityEvent _onAdBreakRewardedError;
        public UnityEvent OnAdBreakRewardedError => _onAdBreakRewardedError;

        public void BeginAdBreak()
        {
            CrazyAds.Instance.beginAdBreak(
                () => _onAdBreakCompleted.Invoke(),
                () => _onAdBreakError.Invoke()
                );
        }

        public void BeginAdBreakRewarded()
        {
            CrazyAds.Instance.beginAdBreakRewarded(
                () => _onAdBreakRewardedCompleted.Invoke(),
                () => _onAdBreakRewardedError.Invoke()
            );
        }
    }
}