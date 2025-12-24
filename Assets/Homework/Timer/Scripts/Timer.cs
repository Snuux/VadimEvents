using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action OnStarted;
    public event Action OnFinished;
    public event Action OnSecondTicked;
    public event Action OnChanged;
    public event Action OnSetuped;
    
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
        
        OnChanged?.Invoke();
        OnSetuped?.Invoke();
    }

    public void Start()
    {
        if (IsRunning)
            Stop();

        _timerCoroutine = _parent.StartCoroutine(Tick());
        _isPaused = false;
        _isFinished = false;
        
        OnStarted?.Invoke();
        OnChanged?.Invoke();
        OnSecondTicked?.Invoke();
    }

    public void Stop()
    {
        if (_timerCoroutine != null)
            _parent.StopCoroutine(_timerCoroutine);
        
        _currentTime = _targetTime;
        
        OnChanged?.Invoke();
        
        _timerCoroutine = null;
    }

    private IEnumerator Tick()
    {
        float nextSecond = 1;
        
        while (_currentTime >= 0)
        {
            if (_isPaused == false)
            {
                _currentTime -= Time.deltaTime;
                
                float timeFromStart = _targetTime - _currentTime;

                if (timeFromStart >= nextSecond)
                {
                    OnSecondTicked?.Invoke();
                    nextSecond += 1f;
                }
                
                OnChanged?.Invoke();
            }
            
            yield return null;
        }
        
        _timerCoroutine = null;
        OnFinished?.Invoke();
        _isFinished = true;
    }
}