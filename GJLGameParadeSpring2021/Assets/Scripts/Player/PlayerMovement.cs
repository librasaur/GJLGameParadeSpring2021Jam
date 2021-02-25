using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        
        [SerializeField] private float _speed = 30f;
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Player Input")]
        [SerializeField] private KeyCode _leftKey;
        [SerializeField] private KeyCode _rightKey;
        [SerializeField] private KeyCode _jumpKey;
        [SerializeField] private KeyCode _crouchKey;

        private float _horizontalMov;
        private bool jump, crouch;

        private void Start()
        {
            if (!_rigidbody) GetComponent<Rigidbody>();
            if (!_controller) GetComponent<CharacterController>();
        }


        private void Update()
        {
            // Get movement input
            if (Input.GetKey(_leftKey)) _horizontalMov = -1;
            else if (Input.GetKey(_rightKey)) _horizontalMov = 1;
            else _horizontalMov = 0;

            if (Input.GetKeyDown(_jumpKey))
                jump = true;
            
            if (Input.GetKeyDown(_crouchKey))
                crouch = true;
            else if (Input.GetKeyUp(_crouchKey))
                crouch = false;
        }

        private void FixedUpdate()
        {
            //Move player
            _horizontalMov *= _speed * Time.deltaTime;
            _controller.Move(_horizontalMov, crouch, jump);
            
            jump = false;
        }
    }
}
