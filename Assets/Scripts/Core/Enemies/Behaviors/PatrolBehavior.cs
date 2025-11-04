using UnityEngine;

namespace Core.Enemies.Behaviors
{
    public class PatrolBehavior : MonoBehaviour
    {
        [SerializeField] private float _movementDistance = 1f;
        [SerializeField] private float _speed = 1f;

        private Vector2 _startPosition;
        private int direction = 1;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            Navigate();
        }

        private void Navigate()
        {
            transform.Translate(Vector2.right * (direction * _speed * Time.deltaTime));

            var offset = transform.position.x - _startPosition.x;
            if (Mathf.Abs(offset) >= _movementDistance)
            {
                direction *= -1;

                var clampedX = Mathf.Clamp(transform.position.x, _startPosition.x - _movementDistance, _startPosition.x + _movementDistance);
                transform.position = new Vector2(clampedX, transform.position.y);
            }
        }
    }
}