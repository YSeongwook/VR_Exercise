using UnityEngine;
using UnityEngine.UI;

public class TempUI : MonoBehaviour
{
    [SerializeField] private Button btnTemp;
    [SerializeField] private Slider sliderTemp;
    
    private void OnEnable()
    {
        if(btnTemp != null)
            btnTemp.onClick.AddListener(OnClick_TemporalBtn);

        if (sliderTemp != null)
            sliderTemp.onValueChanged.AddListener(OnValueChanged_Slider);
    }

    private void OnDisable()
    {
        if (btnTemp != null)
            btnTemp.onClick.RemoveListener(OnClick_TemporalBtn);

        if (sliderTemp != null)
            sliderTemp.onValueChanged.RemoveListener(OnValueChanged_Slider);
    }

    private void OnClick_TemporalBtn()
    {
        Debug.Log("버튼 눌려짐");
    }

    private void OnValueChanged_Slider(float value)
    {
        Debug.Log($"슬라이더 변경 {value}");
    }
    
}
