using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalGemCountText;
    [SerializeField] private AudioClip click;
    
    [SerializeField] GameManager gameManager;


    public void Setup()
    {
        gameObject.SetActive(true);
        finalScoreText.text = GameManager.GetScore().ToString() + "m";
        finalGemCountText.text = "x" + gameManager.GetGemsCollected().ToString();
    }

    public void RestartButton()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 0.7f);
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitButton()
    {
        AudioSource.PlayClipAtPoint(click, transform.position, 0.7f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
