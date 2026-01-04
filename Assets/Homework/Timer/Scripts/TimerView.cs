using TMPro;
using UnityEngine;
using UnityEngine.UI;

class TimerView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    
    [SerializeField] private RectTransform _parentPanelPrefab;
    
    [SerializeField] private Slider _sliderPrefab;
    [SerializeField] private RectTransform _heartFillAreaPrefab;
    [SerializeField] private Image _heartFillImagePrefab;
    
    [SerializeField] private RectTransform _buttonsPanelPrefab;
    
    [SerializeField] private Button _buttonStartPrefab;
    [SerializeField] private Button _buttonStopPrefab;
    [SerializeField] private Button _buttonPausePrefab;
    [SerializeField] private Button _buttonContinuePrefab;
    
    [SerializeField] private TMP_Text _textMaxTimePrefab;
    [SerializeField] private TMP_Text _textTimePrefab;

    private Timer _timer;
    private RectTransform _heartFillArea;

    private Button _buttonStart;
    private Button _buttonStop;
    private Button _buttonPause;
    private Button _buttonContinue;
    private Slider _slider;
    
    private TMP_Text _textMaxTime;
    private TMP_Text _textTime;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        
        RectTransform parentPanel = Instantiate(_parentPanelPrefab, _canvas.transform); 
        _slider = Instantiate(_sliderPrefab, parentPanel);
        
        _textMaxTime =  Instantiate(_textMaxTimePrefab, _slider.GetComponent<RectTransform>());
        _textTime =  Instantiate(_textTimePrefab, _slider.GetComponent<RectTransform>());
        
        _heartFillArea = Instantiate(_heartFillAreaPrefab, parentPanel);
        RectTransform buttonsPanel = Instantiate(_buttonsPanelPrefab, parentPanel);
        
        _buttonStart = Instantiate(_buttonStartPrefab,  buttonsPanel);
        _buttonStop = Instantiate(_buttonStopPrefab,  buttonsPanel);
        _buttonPause = Instantiate(_buttonPausePrefab,  buttonsPanel);
        _buttonContinue = Instantiate(_buttonContinuePrefab,  buttonsPanel);

        _buttonStart.onClick.AddListener(StartTimer);
        _buttonStop.onClick.AddListener(StopTimer);
        _buttonPause.onClick.AddListener(PauseTimer);
        _buttonContinue.onClick.AddListener(ResumeTimer);

        _timer.ReactiveCurrentTime.Changed += UpdateSlider;
        _timer.ReactiveCurrentTime.Changed += UpdateTimeText;
        _timer.ReactiveCurrentTime.Changed += UpdateHearts;
        
        _timer.Configured += UpdateMaxTimeText;
        _timer.Finished += UpdateMaxTimeTextFinished;
    }

    private void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonStop.onClick.RemoveAllListeners();
        _buttonPause.onClick.RemoveAllListeners();
        _buttonContinue.onClick.RemoveAllListeners();
        
        _timer.ReactiveCurrentTime.Changed -= UpdateSlider;
        _timer.ReactiveCurrentTime.Changed -= UpdateTimeText;
        _timer.ReactiveCurrentTime.Changed -= UpdateHearts;
        
        _timer.Configured -= UpdateMaxTimeText;
        _timer.Finished -= UpdateMaxTimeTextFinished;
    }

    private void UpdateTimeText(float oldTime, float currentTime) => _textTime.text =  Mathf.FloorToInt(currentTime) + " sec";

    private void UpdateMaxTimeText() => _textMaxTime.text = "Timer: " + _timer.ReactiveTargetTime.Value.ToString("00") + " sec";
    
    private void UpdateMaxTimeTextFinished() => _textMaxTime.text = "Yeah, timer Finished!!!";

    private void UpdateSlider(float oldTime, float currentTime) => _slider.value = currentTime / _timer.ReactiveTargetTime.Value;

    private void UpdateHearts(float oldTime, float currentTime)
    {
        int secondsCount = Mathf.FloorToInt(currentTime);
        
        for (int i = 0; i < _heartFillArea.childCount; i++)
            Destroy(_heartFillArea.GetChild(i).gameObject);
        
        for (int i = 0; i < secondsCount; i++)
            Instantiate(_heartFillImagePrefab, _heartFillArea);
    }

    private void StartTimer() => _timer.Start();

    private void StopTimer() => _timer.Stop();

    private void PauseTimer() => _timer.Pause();

    private void ResumeTimer() => _timer.Resume();
}