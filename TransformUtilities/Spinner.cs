using UnityEngine;

namespace UUC.TransformUtilities
{
    /// <summary>
    /// Component which makes the game object spin on a defined (world) axis.
    ///
    /// <para>Created by @LeHoppel.</para>
    /// </summary>
    public class Spinner : MonoBehaviour
    {
        [Tooltip("The amount of seconds it takes to complete a full spin rotation.")]
        [SerializeField] private float spinFrequency;
        
        [Tooltip("The (world space) axis on which the object spins.")]
        [SerializeField] private Vector3 spinAxis = Vector3.up;
        
        [Tooltip("If true, a red line is drawn in the editor visualizing the spin axis.")]
        [SerializeField] private bool debugDrawSpinAxis;

        private Quaternion _initialRotation;
        private float _spinSpeed;
        
    #region Public Update Methods

        public void UpdateSpinFrequency(float newFrequency) 
        {
            spinFrequency = newFrequency;
            ResetSettings();
        }

        public void UpdateSpinAxis(Vector3 newAxis)
        {
            spinAxis = newAxis;
            ResetSettings();
        }
    #endregion

        private void ResetSettings()
        {
            _initialRotation = transform.rotation;
            spinAxis.Normalize();
            
            if (spinFrequency != 0)
                _spinSpeed = 360 / spinFrequency;
        }
        
        private void OnEnable()
        {
            ResetSettings();
        }

        private void OnDisable()
        {
            transform.rotation = _initialRotation;
        }

        private void FixedUpdate()
        {
            transform.Rotate(spinAxis, Time.fixedDeltaTime * _spinSpeed, Space.World);
        }
        
        private void OnDrawGizmosSelected()
        {
            if (!debugDrawSpinAxis)
                return;
            
            Gizmos.color = Color.red;
            
            Gizmos.DrawLine(transform.position, transform.position + spinAxis.normalized);
        }
    }
}
