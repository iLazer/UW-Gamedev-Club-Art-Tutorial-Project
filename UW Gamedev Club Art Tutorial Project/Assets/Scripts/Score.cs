using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    bool dead;
    [SerializeField] TMP_Text scoreText;
    public static Score Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead) return;
        scoreText.text = "Score: " + score;
    }

    public void Die()
    {
        dead = true;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
