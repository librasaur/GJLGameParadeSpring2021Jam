using UnityEngine;

namespace CharacterSelection
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Characters/New Character")]
    [System.Serializable]
    public class CharacterObject : ScriptableObject
    {
        public string characterName;
        public GameObject characterPrefab;
    }
}
