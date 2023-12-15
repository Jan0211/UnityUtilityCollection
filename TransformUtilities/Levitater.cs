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

        [Tooltip("If true, a red line is drawn in the editor from minimum to maximum levitation position.")]
        [SerializeField] private bool debugDrawLevitation;
        

        private Vector3 _initialPosition;

        private Vector3 _minPos;
        private Vector3 _maxPos;
        
        private float _levitationSpeed;

        private bool _movingUp = true;
        
        
    #region Public Update Methods
        public void UpdateLevitationRange(float newRange) 
        {
            levitationRange = newRange;
            ResetSettings();
        }
        
        public void UpdateLevitationFrequency(float newFrequency) 
        {
            levitationFrequency = newFrequency;
            ResetSettings();
        }

        public void UpdateLevitationAxis(Vector3 newAxis)
        {
            levitationAxis = newAxis;
            ResetSettings();
        }
    #endregion

        private void ResetSettings()
        {
            _initialPosition = transform.position;
            
            levitationRange = Mathf.Abs(levitationRange);
            levitationAxis.Normalize();

            _minPos = _initialPosition;
            _maxPos = _initialPosition + levitationRange * levitationAxis;

            if (levitationFrequency != 0)
                _levitationSpeed = 2 * levitationRange / levitationFrequency;
        }
        
        private void OnEnable()
        {
            ResetSettings();
        }

        private void OnDisable()
        {
            transform.position = _initialPosition;
        }

        private void FixedUpdate()
        {
            // todo: change velocity over time so it's not linear anymore and slowly comes to a stop
            
            transform.position += Time.fixedDeltaTime * _levitationSpeed * (_movingUp ? 1 : -1) * levitationAxis;
            Vector3 position = transform.position;
            
            if (_movingUp && Vector3.Dot(_maxPos - position, levitationAxis) <= 0)
            {
                _movingUp = !_movingUp;
                transform.position = _maxPos;
            }
            else if (!_movingUp && Vector3.Dot(_minPos - position, levitationAxis) >= 0)
            {
                _movingUp = !_movingUp;
                transform.position = _minPos;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (!isActiveAndEnabled || !debugDrawLevitation)
                return;
            
            Gizmos.color = Color.red;
            
            if (Application.isPlaying)
                Gizmos.DrawLine(_initialPosition, _initialPosition + levitationRange * levitationAxis.normalized);
            else
            {
                Vector3 position = transform.position;
                Gizmos.DrawLine(position, position + levitationRange * levitationAxis.normalized);
            }
        }
    }
}
