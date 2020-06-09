using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    
    void Start(){
        PlayerStats.instance.onHealthUpdated += UpdateLivesText;
        GameManager.instance.onGameEnded += UpdateEndGameText;
    }
    
    private void UpdateLivesText(int health){
        livesText.text = health.ToString() + " LIVES";
    }

    private void UpdateEndGameText(){
        livesText.text = "You are DEAD!";
    }
}
