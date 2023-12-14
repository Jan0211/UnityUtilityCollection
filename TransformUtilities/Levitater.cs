using UnityEngine;

namespace UUC.TransformUtilities
{
    /// <summary>
    /// Component which makes the game object levitate (float up and down).
    ///
    /// <para>Created by @LeHoppel.</para>
    /// </summary>
    public class Levitater : MonoBehaviour
    {
        [Tooltip("The (world space) distance between the lowest and highest point in the levitation cycle.")]
        [SerializeField] private float levitationRange;
        
        [Tooltip("The amount of seconds it takes to complete a full levitation cycle.")]
        [SerializeField] private float levitationFrequency;
        
        [Tooltip("The (world space) axis along which the object moves.")]
        [SerializeField] private Vector3 levitationAxis = Vector3.up;

        private Vector3 _initialLocalPosition;
        private Vector3 _localLevitationAxis;

        private Vector3 _localMin;
        private Vector3 _localMax;
        
        private float _levitationSpeed;

        private bool _movingUp = true;

        private void OnEnable()
        {
            levitationRange = Mathf.Abs(levitationRange);

            Transform objectTransform = transform;
            _localLevitationAxis = objectTransform.InverseTransformVector(levitationAxis.normalized);
            _initialLocalPosition = objectTransform.localPosition;

            _localMin = _initialLocalPosition;
            _localMax = _initialLocalPosition + levitationRange * _localLevitationAxis;

            if (levitationFrequency != 0)
                _levitationSpeed = 2 * levitationRange / levitationFrequency;
        }

        private void OnDisable()
        {
            transform.localPosition = _localMin;
        }

        private void FixedUpdate()
        {
            // todo: change velocity over time so it's not linear anymore and slowly comes to a stop
            
            transform.localPosition += Time.fixedDeltaTime * _levitationSpeed * (_movingUp ? 1 : -1) * _localLevitationAxis;
            Vector3 localPosition = transform.localPosition;
            
            if (_movingUp && Vector3.Dot(_localMax - localPosition, _localLevitationAxis) <= 0)
            {
                _movingUp = !_movingUp;
                transform.localPosition = _localMax;
            }
            else if (!_movingUp && Vector3.Dot(_localMin - localPosition, _localLevitationAxis) >= 0)
            {
                _movingUp = !_movingUp;
                transform.localPosition = _localMin;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Vector3 position = transform.position;
            Gizmos.DrawLine(position, position + levitationRange * levitationAxis.normalized);
        }
    }
}
