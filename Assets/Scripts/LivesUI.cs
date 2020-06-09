using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    
    void Start(){
        PlayerStats.instance.onHealthUpdated += UpdateLivesText;
    }
    
    private void UpdateLivesText(int health){
        livesText.text = health.ToString() + " LIVES";
    }
}
