using TMPro;
using UnityEngine;
using UnityEngine.UI;

class TimerView : MonoBehaviour
{
    [SerializeField] private TimerPlayer _player;
    
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

    private void Start()
    {
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
        
        _timer = _player.GetTimer();

        _buttonStart.onClick.AddListener(StartTimer);
        _buttonStop.onClick.AddListener(StopTimer);
        _buttonPause.onClick.AddListener(PauseTimer);
        _buttonContinue.onClick.AddListener(ResumeTimer);

        _timer.OnChanged += UpdateSlider;
        _timer.OnChanged += UpdateTimeText;
        _timer.OnSecondTicked += UpdateHearts;
        _timer.OnSetuped += UpdateMaxTimeText;
        _timer.OnFinished += UpdateMaxTimeTextFinished;

        UpdateTimeText();
        UpdateMaxTimeText();
        UpdateSlider();
        UpdateHearts();
    }

    private void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonStop.onClick.RemoveAllListeners();
        _buttonPause.onClick.RemoveAllListeners();
        _buttonContinue.onClick.RemoveAllListeners();
        
        _timer.OnChanged -= UpdateSlider;
        _timer.OnChanged -= UpdateTimeText;
        _timer.OnSecondTicked -= UpdateHearts;
        _timer.OnSetuped -= UpdateMaxTimeText;
        _timer.OnFinished -= UpdateMaxTimeTextFinished;
    }

    private void UpdateTimeText() => _textTime.text =  Mathf.FloorToInt(_timer.CurrentTime) + " sec";

    private void UpdateMaxTimeText() => _textMaxTime.text = "Timer: " + _timer.TargetTime.ToString("00") + " sec";
    
    private void UpdateMaxTimeTextFinished() => _textMaxTime.text = "Yeah, timer Finished!!!";

    private void UpdateSlider() => _slider.value = _timer.CurrentTime / _timer.TargetTime;

    private void UpdateHearts()
    {
        int secondsCount = Mathf.FloorToInt(_timer.CurrentTime);
        
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