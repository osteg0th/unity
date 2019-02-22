using TMPro;
using UnityEngine;

public class ScoreManger : MonoBehaviour {
    public TextMeshProUGUI score;
    public GameObject winPanel;
    [HideInInspector]
    public int scorePoint;
    void Start()
    {
        score.text = PlayerPrefs.GetInt("Score",0).ToString();
        scorePoint = PlayerPrefs.GetInt("Score", 0);
    }
    void Update()
    {
        if (scorePoint > 1000)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (scorePoint > 1000)
            PlayerPrefs.DeleteKey("Score");
            
    }
	public void ScoreUpdater(int scoreBoost)
    {
        scorePoint += scoreBoost;
        PlayerPrefs.SetInt("Score", scorePoint);
        PlayerPrefs.Save(); 
        score.text = scorePoint.ToString();
    }
}
