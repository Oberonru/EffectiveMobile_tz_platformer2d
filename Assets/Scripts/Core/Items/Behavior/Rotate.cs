using UnityEngine;

namespace Core.Items.Behavior
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 100f;

        private void Update()
        {
            Rotation();
        }

        private void Rotation()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);
        }
    }
}