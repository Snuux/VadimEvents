using UnityEngine;

namespace Homework.Timer.Scripts
{
    class TimerPlayer : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
    
        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(this);
            _timer.SetTargetTime(10);
        
            _timerView.Initialize(_timer);
        
            _timer.Start();
        }

        private void Update()
        {
            RandomRangeOnKeyF();
        }

        private void RandomRangeOnKeyF()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _timer.Stop();
                _timer.SetTargetTime(Random.Range(1, 30));
                _timer.Start();
            }
        }
    }
}