using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween 네임스페이스 사용

public class OpenDoor : MonoBehaviour
{
    // OnClick_OpenDoorButton 메서드
    public void OnClick_OpenDoorButton()
    {
        // DOTween Animation 컴포넌트 가져오기
        DOTweenAnimation dotweenAnimation = GetComponent<DOTweenAnimation>();

        // DOTween Animation 재생
        if (dotweenAnimation != null)
        {
            dotweenAnimation.DOPlay();
            Debug.Log("문이 열렸습니다."); // 한국어로 디버그 메시지 출력
        }
        else
        {
            Debug.Log("DOTweenAnimation 컴포넌트를 찾을 수 없습니다."); // 한국어로 디버그 메시지 출력
        }
    }
}