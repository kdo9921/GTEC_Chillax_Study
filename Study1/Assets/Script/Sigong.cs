using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);    // 낙하물이 생성될 위치 x 랜덤 지정 -9~9
        transform.position = new Vector3(x, 6.0f, 0.0f);    // 낙하물 위치 = (x,6,0). 2D 게임이니 z축은 지정 안함
        gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f, 0.5f); // 낙하물의 중력을 0.1~0.5로 랜덤 지정
        // 스크립트가 적용된 게임오브젝트의 Rigidbody2D 컴포넌트를 가져오고, 가져온 컴포넌트의 gravityScale 속성을 랜덤값으로 지정
        Destroy(gameObject, 5.0f);
        // 5초 후 오브젝트 제거 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360.0f * Time.deltaTime);    //안배운건데 심심해서 넣어봄. 빙글빙글 회전 시키는 메소드임.
    }

    private void OnTriggerEnter2D(Collider2D collision) // 트리거로 설정한 콜라이더에 다른 콜라이더가 들어온게 감지되었을 경우 실행되는 콜백 메소	
    {                 // 매개변수의 (Collider2D collision) => 트리거 안에 들어온 2D 콜라이더를 collision이라 부르겠
        if (collision.gameObject.name == "player")  // 감지된 콜라이더가 적용된 게임오브젝트의 이름이 player인 경우 
        {
            GameObject.Find("player").GetComponent<Player>().hurt();    // 게임 오브젝트중 이름이 player인 놈을 찾아서
                                                                        // 찾아낸놈의 컴포넌트중 Player라는걸(여기서는 우리가 만든 스크립트) 찾는다
                                                                        // 찾아낸 스크립트에서 hurt() 메소드를 실행시킨다 
        }
    }
}
