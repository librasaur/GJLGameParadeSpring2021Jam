using UnityEngine;

namespace UI
{
    public class AnimatedPanel : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private string _animationName;
    
        public void Open()
        {
            gameObject.SetActive(true);
            
            _animation[_animationName].speed = 1;
            _animation[_animationName].time = 0;
            _animation.Play(_animationName);
        }

        public void Close()
        {
            _animation[_animationName].speed = -1;
            _animation[_animationName].time = _animation[_animationName].time;
            _animation.Play(_animationName);
        }
    }
}
