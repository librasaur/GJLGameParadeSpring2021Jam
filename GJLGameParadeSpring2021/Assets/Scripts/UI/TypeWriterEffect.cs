using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TypeWriterEffect : MonoBehaviour
    {
        [SerializeField] private Text _textUI;
        [SerializeField] private float _displayDelay = 0.125f;
        [SerializeField] private GameObject _underscoreBlink;
        
        private string _fullText;

        private void Awake()
        {
            if (!_textUI) _textUI = GetComponent<Text>();

            _underscoreBlink.gameObject.SetActive(false);

            _fullText = _textUI.text;
            _textUI.text = "";

            StartCoroutine(DisplayText());
        }

        IEnumerator DisplayText()
        {
            foreach (char c in _fullText)
            {
                _textUI.text += c;
                yield return new WaitForSeconds(_displayDelay);
            }
            
            if(_underscoreBlink) _underscoreBlink.gameObject.SetActive(true);
        }
    }
}
