using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] private CharacterObject[] _characterChoice;
        
        [Header("UI")]
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        
        [Header("Lighting")]
        [SerializeField] private GameObject _spotlight;
        [SerializeField] private float _lightShiftDistance;

        private int _currentlyHighlighted;

        private void Start()
        {
            _currentlyHighlighted = 0;
            _leftButton.interactable = false;
            
            Debug.Log("Highlighting: " + _characterChoice[_currentlyHighlighted].name);
        }

        public void RotateSelection(int direction)
        {
            switch (direction)
            {
                // Move right
                case 1:
                    _currentlyHighlighted++;

                    if (_currentlyHighlighted == _characterChoice.Length - 1)
                    {
                        _rightButton.interactable = false;
                        _leftButton.interactable = true;
                    }
                    else
                        _leftButton.interactable = true;
                    
                    MoveLight(_lightShiftDistance);
                    break;
                
                // Move left
                case -1:
                    _currentlyHighlighted--;

                    if (_currentlyHighlighted == 0)
                    {
                        _leftButton.interactable = false;
                        _rightButton.interactable = true;
                    }
                    else
                        _rightButton.interactable = true;
                    
                    MoveLight(-_lightShiftDistance);
                    break;
            }
        }

        private void MoveLight(float amountToMove)
        {
            if (!_spotlight) return;

            var newPosition = _spotlight.transform.position;
            newPosition = new Vector3(newPosition.x + amountToMove, newPosition.y, newPosition.z);
            
            _spotlight.transform.position = newPosition;
        }

        public void LetTheGamesBegin(string nextLevel)
        {
            PlayerPrefs.SetInt("Character", _currentlyHighlighted);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
