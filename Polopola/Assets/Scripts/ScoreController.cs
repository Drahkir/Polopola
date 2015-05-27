using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreController : MonoBehaviour
    {
        public static int CurrentScore;       
        Text _text;                     


        void Awake()
        {
            _text = GetComponent<Text>();
            CurrentScore = 0;
        }


        void Update()
        {
            _text.text = "Score: " + CurrentScore;
        }
    }
}