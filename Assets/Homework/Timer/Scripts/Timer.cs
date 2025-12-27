using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action Started;
    public event Action Finished;
    public event Action<float> Changed;
    public event Action Configured;
    
    private float _currentTime;
    private float _targetTime;
    private bool _isPaused;
    private bool _isFinished;
    
    private readonly MonoBehaviour _parent;
    private Coroutine _timerCoroutine;

    public Timer(MonoBehaviour parent, float currentTime = 0)
    {
        _parent = parent;
        _currentTime = currentTime;
    }

    public float CurrentTime => _currentTime;
    public float TargetTime => _targetTime;
    
    public bool IsRunning => _timerCoroutine != null;
    public bool IsPaused => _isPaused;
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
        
        _targetTime = time;
        _currentTime = _targetTime;
        
        Changed?.Invoke(_currentTime);
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
        Changed?.Invoke(0);
    }

    public void Stop()
    {
        if (_timerCoroutine != null)
            _parent.StopCoroutine(_timerCoroutine);
        
        _currentTime = _targetTime;
        
        Changed?.Invoke(_targetTime);
        
        _timerCoroutine = null;
    }

    private IEnumerator Tick()
    {
        while (_currentTime >= 0)
        {
            if (_isPaused == false)
            {
                _currentTime -= Time.deltaTime;
                Changed?.Invoke(_currentTime);
            }
            
            yield return null;
        }
        
        _currentTime = 0;
        _timerCoroutine = null;
        Finished?.Invoke();
        _isFinished = true;
    }
}