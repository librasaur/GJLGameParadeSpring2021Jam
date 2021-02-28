using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class CharacterSelectionManager : MonoBehaviour
    {
        [SerializeField] private CharacterObject[] _characterChoice;
        
        [Header("UI")]
        [SerializeField] private Button _leftButton, _rightButton;
        
        [Header("Lighting")]
        [SerializeField] private GameObject _spotlight;
        [SerializeField] private float _lightShiftDistance;

        private int _currentlyHighlighted;

        private void Start()
        {
            _currentlyHighlighted = 1; // Set to 1 so highlights middle character

            _leftButton.interactable = true;
            _rightButton.interactable = true;
            
            Debug.Log("Highlighting: " + _characterChoice[_currentlyHighlighted].name);
        }

        public void RotateSelection(int direction)
        {
            switch (direction)
            {
                // Move right
                case 1:
                    // If user reaches far right, disable right button
                    if (_currentlyHighlighted+1 == _characterChoice.Length-1)
                    {
                        _rightButton.interactable = false;
                        _currentlyHighlighted++;
                    }
                    // Otherwise move right and enable left button 
                    else
                    {
                        _leftButton.interactable = true;
                        _currentlyHighlighted++;
                    }
                    
                    MoveLight(_lightShiftDistance);
                    
                    Debug.Log("Highlighting: " + _characterChoice[_currentlyHighlighted].name);
                    break;
                
                // Move left
                case -1:
                    // If user reaches far left, disable right left
                    if (_currentlyHighlighted-1 == 0)
                    {
                        _leftButton.interactable = false;
                        _currentlyHighlighted--;
                    }
                    // Otherwise move left and enable right button 
                    else
                    {
                        _rightButton.interactable = true;
                        _currentlyHighlighted--;
                    }
                    
                    MoveLight(-_lightShiftDistance);
            
                    Debug.Log("Highlighting: " + _characterChoice[_currentlyHighlighted].name);
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

        public void LetTheGamesBegin(int nextLevel)
        {
            PlayerPrefs.SetInt("Character", _currentlyHighlighted);
            
            Debug.Log("Selected: " + _characterChoice[_currentlyHighlighted].name);

            SceneManager.LoadScene(nextLevel);
        }
    }
}
