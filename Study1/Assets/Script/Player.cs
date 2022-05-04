using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3; // 플레이어의 체력 (비공개)
    public float moveSpeed = 3.0f;  // 플레이어의 속도 (공개, 다른 클래스나 게임오브젝트, 유니티 에디터에서 접근 및 수정 가능)
    // Start is called before the first frame update
    void Start()
    {
        // 현재 스크립트가 적용된 게임 오브젝트가 생성되기 직전 실행되는 메소드
        // 지금 Player 스크립트에서는 미사용 하니 지워도 무방
    }

    // Update is called once per frame
    void Update()   // 매 프레임마다 실행될 코드
    {
        float position = Input.GetAxis("Horizontal");   // position에 현재 방향키 눌림 상태를 감지해서 값(왼쪽:-1, 안눌림:0, 오른쪽:1) 저장
        float move = position * moveSpeed * Time.deltaTime; // 이동할 (상대)x좌표 = 방향 x 속도 x 1/fps.    fps : 초당 프레임 수
        // Time.deltaTime (1/fps) 를 곱해주는 이유 = 보통 싸구려 모니터에 수직 동기화 해도 초당 60프레임은 나오는데 
        // Time.deltaTime로 나눠주지 않으면 1초 꾹 누르면 moveSpeed * 60칸 나가는것
        // + 컴퓨터와 모니터 사양에 따라 이동속도가 달라짐
        // 이런 상황을 방지하고 프레임에 관계없이 일정한 속도를 주기 위해 1/초당프레임수로 나눠줌
        transform.position = transform.position + new Vector3(move, 0, 0);
        // 게임 오브젝트의 위치 = 현재 위치 + move 
    }

    public void hurt()  // public 메소드(함수)라서 외부에서 접근 가능. 중요한 속성에 public으로 직접 접근은 위험하기 때문에 비공개(private)로 설정 후
    {                   // public 메소드로 접근하는것을 권장함. 자세한 내용은 2학년때 객체지향 배울때 배우거나 미리 알고싶으면 연락하셈. 카톡 or me@darae.dev 
        hp = hp - 1;    // 체력 1 깍음
        Debug.Log(hp);  // 현재 채력 출력
        if (hp <= 0)    // 체력이 0 이하라면
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;   // GameManager라는 이름의 게임 오브젝트를 찾아서 
            // 찾아낸 오브젝트의 컴포넌트중 GameManager라는 컴포넌트(여기서는 우리가 만든 스크립트)를 찾아내고 그 컴포넌트의 값중 isGameOver의 값을 true로 변경
            Destroy(gameObject);    //체력이 0이니 사망처리. 오브젝트 제거해줌.
        }
    }
}
