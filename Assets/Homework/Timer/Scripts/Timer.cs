using System;
using System.Collections;
using Homework.Reactive;
using UnityEngine;

namespace Homework.Timer.Scripts
{
    public class Timer
    {
        public event Action Started;
        public event Action Finished;
        public event Action Configured;
    
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _targetTime;
    
        private bool _isPaused;
        private bool _isFinished;
    
        private readonly MonoBehaviour _parent;
        private Coroutine _timerCoroutine;

        public Timer(MonoBehaviour parent, float maxTime = 0)
        {
            _parent = parent;
        
            _currentTime = new ReactiveVariable<float>(maxTime);
            _targetTime = new ReactiveVariable<float>(maxTime);
        }

        public IReadOnlyReactiveVariable<float> ReactiveCurrentTime => _currentTime;
        public IReadOnlyReactiveVariable<float> ReactiveTargetTime => _targetTime;
    
        public bool IsRunning => _timerCoroutine != null;
        public bool IsFinished => _isFinished;

        public void Pause() => _isPaused = true;

        public void Resume() => _isPaused = false;

        public void SetTargetTime(float time)
        {
            if (IsRunning)
            {
                Stop();
                return;
            }

            _targetTime.Value = time;
            _currentTime.Value = _targetTime.Value;
        
            Configured?.Invoke();
        }

        public void Start()
        {
            if (IsRunning)
                Stop();

            _timerCoroutine = _parent.StartCoroutine(Tick());
            _isPaused = false;
            _isFinished = false;
        
            Started?.Invoke();
        }

        public void Stop()
        {
            if (_timerCoroutine != null)
                _parent.StopCoroutine(_timerCoroutine);
        
            _currentTime.Value = _targetTime.Value;
            _timerCoroutine = null;
        }

        private IEnumerator Tick()
        {
            while (_currentTime.Value >= 0)
            {
                if (_isPaused == false)
                    _currentTime.Value -= Time.deltaTime;
            
                yield return null;
            }
        
            _currentTime.Value = 0;
            _timerCoroutine = null;
            Finished?.Invoke();
            _isFinished = true;
        }
    }
}