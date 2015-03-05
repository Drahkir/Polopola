using UnityEngine;

namespace Assets.Scripts
{
    public class BackgroundRepeater : MonoBehaviour
    {
        private Transform _cameraTransform;
        private float _spriteHeight;

        // Use this for initialization
        void Start ()
        {
            _cameraTransform = Camera.main.transform;
            var spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
            _spriteHeight = spriteRenderer.sprite.bounds.size.y;
        }
	
        // Update is called once per frame
        void Update () {
            if ((transform.position.y + _spriteHeight) < _cameraTransform.position.y)
            {
                var newPos = transform.position;
                newPos.y += 2.0f * _spriteHeight;
                transform.position = newPos;
            }
        }
    }
}
