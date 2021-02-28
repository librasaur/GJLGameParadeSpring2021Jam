using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerSwitch : MonoBehaviour
    {
        [SerializeField] private Material _bwMat1;
        [SerializeField] private Material _bwMat2;
        [SerializeField] private Material _iceMat;
        [SerializeField] private Material _crystalMat;
        [SerializeField] private KeyCode switchStateButton;
        [SerializeField] private float keyPressTimer;
        private StateSwitch[] objectsWithSwitch;
        private float timeSincePressed;
        public static int _switchID = Shader.PropertyToID("_switch");
        private bool _switchIt;
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
            _switchIt = !_switchIt;
            if (_switchIt)
            {
                if (_bwMat1) _bwMat1.SetFloat(_switchID, 1);
                if (_bwMat2) _bwMat2.SetFloat(_switchID, 0);
                if (_iceMat) _iceMat.SetFloat(_switchID, 1);
                if (_crystalMat) _crystalMat.SetFloat(_switchID, 0);
            }
            else
            {
                if (_bwMat1) _bwMat1.SetFloat(_switchID, 0);
                if (_bwMat2) _bwMat2.SetFloat(_switchID, 1);
                if (_iceMat) _iceMat.SetFloat(_switchID, 0);
                if (_crystalMat) _crystalMat.SetFloat(_switchID, 1);
            }
            
            foreach (var gameObj in objectsWithSwitch)
            {
                gameObj.Switch();
            }
        }
    }
}