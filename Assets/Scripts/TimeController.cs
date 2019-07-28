using UnityEngine;

public class TimeController : MonoBehaviour
{
    //================================ Variables

    [Header("Time")]
    [Tooltip("Day Length in Minutes")]

    [SerializeField] private float _targetDayLength = 0.5f;
    [SerializeField] [Range(0f, 1f)] private float _timeOfDay;
    [SerializeField] private int _dayNumber = 0; 
    [SerializeField] private int _yearNumber = 0;
    private float _timeScale = 100f;
    [SerializeField] private int _yearLength = 100;

    public bool pause = false;

    [Header("Sun Light")]
    [SerializeField] private Transform dailyRotation;
    [SerializeField] private Light sun;
    private float intensity;
    [SerializeField] private float sunBaseIntensity = 1.0f;
    [SerializeField] private float sunVariation = 1.0f;
    [SerializeField] private Gradient sunColor;

    //================================ Methods

    private void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }
        AdjustSunRotation();
       // SunIntensity();
       // AdjustSunColor();
    }

    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);
    }

    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; 

        if (_timeOfDay > 1) 
        {
            _dayNumber++;
            _timeOfDay -= 1;

            if (_dayNumber > _yearLength) 
            {
                _yearNumber++;
                _dayNumber = 0;
            }
        }
    }

    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 360.0f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    private void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }

    private void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }

    //================================ Getters & Setters
    public float targetDayLength { get { return _targetDayLength; } }
    public float timeOfDay { get { return _timeOfDay; } }
    public int dayNumber { get { return _dayNumber; } }
    public int yearNumber { get { return _yearNumber; } }
    public float yearLength { get { return _yearLength; } }

}