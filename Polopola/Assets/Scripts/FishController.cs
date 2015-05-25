using UnityEngine;

namespace Assets.Scripts
{
    public class FishController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
