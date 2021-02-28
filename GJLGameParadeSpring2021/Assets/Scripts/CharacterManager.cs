using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private Transform _startPos;

    private void Awake()
    {
        int character = PlayerPrefs.GetInt("Character");
        Instantiate(_characters[character], _startPos);
    }
}
