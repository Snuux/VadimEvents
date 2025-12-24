using UnityEngine;

class TimerPlayer : MonoBehaviour
{
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(this);
        _timer.SetTargetTime(10);
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

    public Timer GetTimer() => _timer;
}