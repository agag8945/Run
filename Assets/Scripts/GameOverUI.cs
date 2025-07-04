using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        // 초기 상태 설정
        gameOverText.alpha = 0;
        scoreText.alpha = 0;

        // GameOver 텍스트: 페이드 인 → 무한 깜빡임
        gameOverText.DOFade(1f, 0.5f)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                gameOverText.DOFade(0.3f, 0.5f)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            });

        // Score 텍스트: 위로 튀어나오듯이 등장 + 스케일 업
        RectTransform scoreRect = scoreText.GetComponent<RectTransform>();
        Vector2 startPos = scoreRect.anchoredPosition;
        scoreRect.anchoredPosition = startPos + new Vector2(0, -100);
        scoreText.transform.localScale = Vector3.zero;

        Sequence scoreSeq = DOTween.Sequence();
        scoreSeq.Append(scoreText.DOFade(1f, 0.5f))
                .Join(scoreRect.DOAnchorPos(startPos, 0.5f).SetEase(Ease.OutBack))
                .Join(scoreText.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack));
    }
}
