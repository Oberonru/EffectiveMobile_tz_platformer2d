using UnityEngine;

namespace Core.Items.Behavior
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private float amplitude = 2f; 
        [SerializeField] private float speed = 2f;
        private Vector3 _startPos;

        private void Start()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            var offsetY = Mathf.Sin(Time.time * speed) * amplitude;
            transform.position = _startPos + new Vector3(0, offsetY, 0);
        }
    }
}