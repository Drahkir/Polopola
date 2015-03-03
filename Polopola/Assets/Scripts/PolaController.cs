using UnityEngine;

namespace Assets.Scripts
{
    public class PolaController : MonoBehaviour
    {
        public float MoveSpeed;
        private Vector3 _moveDirection;
        private Polarity _polo;
        private Polarity _pola;
        private float _cameraWidth;

        public enum Polarity
        {
            Red,
            Black,
        }

        void Start()
        {
            _polo = Polarity.Red;
            _pola = Polarity.Black;
            _cameraWidth = Camera.main.pixelWidth;
        }

        void Update()
        {
            var currentPosition = transform.position;

            if (Input.GetButton("Fire1"))
            {
//                var moveToward = _polo == _pola ? new Vector3((Camera.main.aspect * Camera.main.orthographicSize) / 2, 0, 0) : new Vector3(-2000, 0, 0);
                var moveToward = _polo == _pola ? new Vector3(_cameraWidth, 0, 0) : new Vector3(0, 0, 0);
                _moveDirection = moveToward - new Vector3(currentPosition.x, 0, 0);
                _moveDirection.z = 0;
                _moveDirection.Normalize();
                var target = _moveDirection * MoveSpeed + currentPosition;
                transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (Input.mousePosition.x > _cameraWidth / 2)
                {
                    _polo = _polo == Polarity.Black ? Polarity.Red : Polarity.Black;
                }
                else
                {
                    _pola = _pola == Polarity.Black ? Polarity.Red : Polarity.Black;
                }
            }
        }
    }
}
