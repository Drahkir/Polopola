using UnityEngine;

namespace Assets.Scripts
{
    public class PoloController : MonoBehaviour
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
                var moveToward = _polo == _pola ? new Vector3(_cameraWidth * -1, 0, 0) : new Vector3(0, 0, 0);
                _moveDirection = moveToward - new Vector3(currentPosition.x, 0, 0);
                _moveDirection.z = 0;
                _moveDirection.Normalize();
                var target = _moveDirection * XMoveSpeed + currentPosition;
                currentPosition = Vector3.Lerp(currentPosition, target, Time.deltaTime);

                if (currentPosition.x <= (-_cameraWidth / 100) - 1f)
                {
                    currentPosition.x = (-_cameraWidth / 100) - 1f;
                }
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
            EnforceBounds();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("enemy"))
            {
                Application.LoadLevel("GameOver");
            }
            else if (other.CompareTag("fish"))
            {
                ScoreController.CurrentScore++;
                Destroy(other.gameObject);
            }
        }

        private void EnforceBounds()
        {
            var newPosition = transform.position;
            var mainCamera = Camera.main;
            var cameraPosition = mainCamera.transform.position;

            var xDist = mainCamera.aspect * mainCamera.orthographicSize;
            var xMax = cameraPosition.x - .2f;
            var xMin = cameraPosition.x - xDist;

            if (newPosition.x < xMin || newPosition.x > xMax)
            {
                newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            }
            transform.position = newPosition;
        }
    }
}
