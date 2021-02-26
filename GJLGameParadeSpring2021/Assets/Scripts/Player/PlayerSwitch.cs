using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerSwitch : MonoBehaviour
    {
        [SerializeField] private KeyCode switchStateButton;
        [SerializeField] private float keyPressTimer;
        private StateSwitch[] objectsWithSwitch;
        private float timeSincePressed;
        void Awake()
        {
            objectsWithSwitch = FindObjectsOfType<StateSwitch>();
        }
    
        void Update()
        {
            timeSincePressed += Time.deltaTime;
            if (timeSincePressed < keyPressTimer) return;
            if (!Input.GetKeyDown(switchStateButton)) return;
            ChangeColors();
            timeSincePressed = 0;
        }

        private void ChangeColors()
        {
            foreach (var gameObj in objectsWithSwitch)
            {
                gameObj.Switch();
            }
        }
    }
}
