using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public float Speed = 3f;
        private Vector3 _newPosition;

        // Use this for initialization
        void Start()
        {
            _newPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            _newPosition.y += Time.deltaTime * Speed;
            transform.position = _newPosition;
        }
    }
}
