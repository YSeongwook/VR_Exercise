using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
// UI 네임스페이스 사용

// DOTween 네임스페이스 사용

public class DoorController : MonoBehaviour
{
    // 문 오브젝트
    public GameObject door;

    // 버튼 오브젝트
    public Button doorButton;

    // 버튼의 텍스트 컴포넌트
    private Text buttonText;

    // 문이 열릴 때의 위치
    public Vector3 openPosition;

    // 문이 닫힐 때의 위치 (원래 위치)
    private Vector3 closedPosition;

    // 문이 열려 있는지 여부를 나타내는 플래그
    private bool isOpen = false;

    // 애니메이션 지속 시간
    public float animationDuration = 1f;

    // 시작 시 초기화 및 버튼 텍스트 설정
    void Start()
    {
        if (door != null)
        {
            closedPosition = door.transform.localPosition;
        }
        else
        {
            Debug.LogError("Door 오브젝트가 설정되지 않았습니다.");
        }

        if (doorButton != null)
        {
            buttonText = doorButton.GetComponentInChildren<Text>();
            buttonText.text = "Open Door";
            doorButton.onClick.AddListener(OnClick_ToggleDoorButton);
        }
        else
        {
            Debug.LogError("DoorButton 오브젝트가 설정되지 않았습니다.");
        }
    }

    // 버튼 클릭 시 호출되는 메서드
    public void OnClick_ToggleDoorButton()
    {
        if (door != null)
        {
            if (isOpen)
            {
                // 문을 닫는 애니메이션 실행
                door.transform.DOLocalMove(closedPosition, animationDuration).OnComplete(() =>
                {
                    Debug.Log("문이 닫혔습니다."); // 한국어로 디버그 메시지 출력
                    buttonText.text = "Open Door"; // 버튼 텍스트 변경
                    isOpen = false;
                });
            }
            else
            {
                // 문을 여는 애니메이션 실행
                door.transform.DOLocalMove(openPosition, animationDuration).OnComplete(() =>
                {
                    Debug.Log("문이 열렸습니다."); // 한국어로 디버그 메시지 출력
                    buttonText.text = "Close Door"; // 버튼 텍스트 변경
                    isOpen = true;
                });
            }
        }
    }
}
