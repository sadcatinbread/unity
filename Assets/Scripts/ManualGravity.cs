    //copied from https://forum.unity.com/threads/why-does-rigidbody-3d-not-have-a-gravity-scale.440415/#post-2847743
    using UnityEngine;
    
     
    [RequireComponent(typeof(Rigidbody))]
    public class ManualGravity : MonoBehaviour
        {
        // Gravity Scale editable on the inspector
        // providing a gravity scale per object
     
        public float gravityScale = 1.0f;
     
        // Global Gravity doesn't appear in the inspector. Modify it here in the code
        // (or via scripting) to define a different default gravity for all objects.
     
        public float globalGravity = -9.81f;
     
        Rigidbody m_rb;
     
        void OnEnable ()
            {
            m_rb = GetComponent<Rigidbody>();
            m_rb.useGravity = false;
            }
     
        void FixedUpdate ()
            {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
            }
        }
