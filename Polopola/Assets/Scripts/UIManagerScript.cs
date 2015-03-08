using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Text BestTime;

//    void Start()
//    {
//        BestTime.text = "Best Time: " + PlayerPrefs.GetString("BestTime");
//    }

    public void StartGame()
    {
        Application.LoadLevel("Polopola");
    }

//    public void ResetScore()
//    {
//        Grid.ResetBestTime();
//        BestTime.text = "Best Time: " + PlayerPrefs.GetString("BestTime");
//    }
}
