using UnityEngine;

namespace Assets.Scripts
{
    public class PolaController : MonoBehaviour
    {
        public float XMoveSpeed;
        private float YMoveSpeed; //This is tied to the camera move speed
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
            YMoveSpeed = CameraController.Speed;
            var currentPosition = transform.position;
            if (Input.GetButton("Fire1"))
            {
                var moveToward = _polo == _pola ? new Vector3(_cameraWidth, 0, 0) : new Vector3(0, 0, 0);
                _moveDirection = moveToward - new Vector3(currentPosition.x, 0, 0);
                _moveDirection.z = 0;
                _moveDirection.Normalize();
                var target = _moveDirection * XMoveSpeed + currentPosition;
                currentPosition = Vector3.Lerp(currentPosition, target, Time.deltaTime);
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
            currentPosition.y += Time.deltaTime * YMoveSpeed;
            transform.position = currentPosition;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("enemy"))
            {
                Application.LoadLevel("GameOver");
            }
        }
    }
}
