using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; // 사망 시 재생할 오디오 클립
    public float jumpForce = 700f; // 점프 힘

    private int jumpCount = 0; // 점프 횟수
    private bool isGrounded = false; // 땅에 닿아 있는지 여부
    private bool isDead = false; // 플레이어가 사망했는지 여부

    private Rigidbody2D playerRigidbody; // 플레이어의 Rigidbody2D 컴포넌트
    private Animator animator; // 플레이어의 Animator 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return; // 플레이어가 사망한 경우 더 이상 업데이트하지 않음
        }
            
        // 점프 입력 처리
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // 점프 횟수 증가
            jumpCount++;

            // 점프 직전에 속도를 순간적으로 제로(0, 0)으로 변경
            playerRigidbody.linearVelocity = Vector2.zero; 

            // 리지드바디에 위쪽으로 힘을 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            // 오디오 소스 재생
            playerAudio.Play();
        }

        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y > 0)
        {
            // 마우스 버튼을 떼면 점프 중인 경우 && 속도의 y값이 양수라면 (위로 상승하고 있다면)
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        // 플레이어의 애니메이션 상태 업데이트
        animator.SetBool("Grounded", isGrounded);
        
    }
}
