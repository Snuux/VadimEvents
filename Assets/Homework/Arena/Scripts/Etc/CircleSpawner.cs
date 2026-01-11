using UnityEngine;

namespace Homework.Arena.Scripts.Etc
{
    public class CircleSpawner : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _prefab;

        [Header("Spawn Settings")]
        [SerializeField] private int _count = 12;
        [SerializeField] private float _radius = 5f;
        [SerializeField] private float _startAngle = 0f;
        [SerializeField] private bool _randomizeAngleOffset = false;

        [Header("Height & Offset")]
        [SerializeField] private float _heightOffset = 0f;
        [SerializeField] private bool _randomizeRadius = false;
        [SerializeField] private Vector2 _radiusRange = new Vector2(3f, 6f);

        [Header("Rotation")]
        [SerializeField] private bool _lookAtCenter = true;
        [SerializeField] private Vector3 _rotationOffset;

        [Header("Parenting")]
        [SerializeField] private bool _parentToThis = true;

        private void Start()
        {
            if (_prefab == null || _count <= 0)
                return;

            float angleStep = 360f / _count;
            float angleOffset = _randomizeAngleOffset ? Random.Range(0f, 360f) : _startAngle;

            for (int i = 0; i < _count; i++)
            {
                float angle = angleOffset + angleStep * i;
                float currentRadius = _randomizeRadius
                    ? Random.Range(_radiusRange.x, _radiusRange.y)
                    : _radius;

                Vector3 position = GetPointOnCircle(angle, currentRadius);
                GameObject instance = Instantiate(_prefab, position, Quaternion.identity);

                if (_lookAtCenter)
                    instance.transform.LookAt(transform.position);

                instance.transform.Rotate(_rotationOffset);

                if (_parentToThis)
                    instance.transform.SetParent(transform);
            }
        }

        private Vector3 GetPointOnCircle(float angle, float radius)
        {
            float rad = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(rad) * radius;
            float z = Mathf.Sin(rad) * radius;

            return transform.position + new Vector3(x, _heightOffset, z);
        }
    }
}