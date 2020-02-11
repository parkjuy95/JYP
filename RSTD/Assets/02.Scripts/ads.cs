using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class ads : MonoBehaviour
{
    public string placementId = "rewardedVideo";

#if UNITY_IOS
    private string gameId = "3378980";
#elif UNITY_ANDROID
    private string gameId = "3378981";
#elif UNITY_EDITOR
    private string gameId = "3378981";
#endif
    void Start()
    {
        if(Monetization.isSupported)
        {
            Monetization.Initialize(gameId, true); // 테스트모드 켜놓음 꼭 나중에 끌것
        }
    }

    public void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;

        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId)
            as ShowAdPlacementContent;
        ad.Show(options);
    }
    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished) // 스킵없이 광고재생을 했을때
        {

        }
        else if (result == ShowResult.Skipped) // 스킵했을때
        {

        }
        else // 실패했을때
        {

        }
    }
}
