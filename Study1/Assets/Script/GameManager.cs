using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false; // 현재 게임 오버인 상태인가? 참(Ture)일 경우 게임 종료
    public GameObject sigong;   // 낙하물 게임 오브젝트 프리팹을 sigong이라는 이름으로 받아옴
    // 프리팹이란? : 여러 컴포넌트로 이미 구성이 완성된, 재사용 가능한 Game Object
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DropSigong");   // DropSigong 코루틴 실행
        // GameManager 스크립트가 적용될 게임 오브젝트(GameManager 오브젝트)가 
        // 생성된 이후 첫 프레임(여기서는 게임 시작과 동시에 생성)에서
        // DropSigong() 코루틴을 실행시킴

        // 코루틴(Coroutine)에 대해 자세히 알고싶으면 -> https://velog.io/@uchang903/UnityCoroutine코루틴의-개념과-활용
        // 간단한 요약 :멀티쓰레드하고 비슷한 효과, 동시에 여러 작업 가능, 프레임 단위인 Update()에서 처리하기 곤란한 작업에 적합 (엄밀히 말하면 멀티쓰레드는 아님)
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 실행될 메소드. 이 스크립트에서는 역활 없음. 지워도 무방.
    }

    IEnumerator DropSigong()    // 코루틴 - IEnumerator 코루틴이름()
    {                           // 낙하물을 생성 시키는 역활
        Instantiate(sigong);        // 위에서 가져온 낙하물 GameObject 프리팹인 sigong을 생산함
        yield return new WaitForSeconds(0.5f);  // 0.5초 대기
        if (isGameOver == false)    // 게임 오버가 아니라면
        {
            StartCoroutine("DropSigong");   // 현재 코루틴 한번 더 실행
        }
    }
}

/*
GameManager 함수의 타임 라인 (쉬운 이해를 위해 0.1초당 1 프레임, 즉 10FPS라고 가정)

--------------------------------------------------------
게임 시작 전 | Start() 호출   |  DropSigong 코루틴 실행
--------------------------------------------------------
 1 프레임   | Update() 호출  |  0.1초 대기
--------------------------------------------------------
 2 프레임   | Update() 호출  |  0.2초 대기
--------------------------------------------------------
 3 프레임   | Update() 호출  |  0.3초 대기
--------------------------------------------------------
 4 프레임   | Update() 호출  |  0.4초 대기
--------------------------------------------------------
 5 프레임   | Update() 호출  |  0.5초. DropSigong 코루틴 실행
--------------------------------------------------------
 6 프레임   | Update() 호출  |  0.1초 대기
--------------------------------------------------------
 7 프레임   | Update() 호출  |  0.2초 대기
--------------------------------------------------------
 8 프레임   | Update() 호출  |  0.3초 대기
--------------------------------------------------------
 9 프레임   | Update() 호출  |  0.4초 대기
--------------------------------------------------------
10 프레임   | Update() 호출  |  0.5초. DropSigong 코루틴 실행

계속 반복

*/