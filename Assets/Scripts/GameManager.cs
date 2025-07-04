using System.Collections; // 코루틴용
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스
    public bool isGameOver = false; // 게임 오버 상태
    public TextMeshProUGUI scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI;  // 게임 오버 시 활성화 할 UI 게임 오브젝트
    private int score = 0; // 게임 점수

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // 인스턴스에 이미 다른 GameManager가 존재하면
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두 개 이상의 매니저가 존재합니다");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            // 게임 오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(0);
        }
    }

    // 점수를 증가 시키는 메서드
    public void AddScore(int newScore)
    {
        // 게임 오버 상태가 아니라면
        if (!isGameOver)
        {
            score += newScore; // 점수 증가
            scoreText.text = "Score: " + score; // UI 텍스트 업데이트
        }
    }

    public void OnPlayerDead()
    {
        // 현재 상태를 게임 오버 상태로 변경
        isGameOver = true;

        // 게임 오버 UI를 활성화
        gameoverUI.SetActive(true);

        // 점수 텍스트 깜빡임 시작
        StartCoroutine(BlinkScoreText());
    }
    
    // 점수 텍스트 깜빡임 코루틴
    private IEnumerator BlinkScoreText()
    {
        while (isGameOver)
        {
            gameoverUI.SetActive(!gameoverUI.activeSelf);
            yield return new WaitForSeconds(0.3f); // 깜빡임 간격
        }

        gameoverUI.SetActive(true); // 게임 재시작 시 보이게
    }
}

