using UnityEngine;
using UnityEngine.Advertisements; // Advertisement class



public class UnityAdController : MonoBehaviour
{
    public static void ShowAd()
    {

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

    }
}
