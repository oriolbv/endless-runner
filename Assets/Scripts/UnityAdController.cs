using UnityEngine;
#if UNITY_ADS // Can only compile ad code on supported platforms 

using UnityEngine.Advertisements; // Advertisement class

#endif



public class UnityAdController : MonoBehaviour
{
    public static void ShowAd()
    {

#if UNITY_ADS

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

#endif

    }
}
