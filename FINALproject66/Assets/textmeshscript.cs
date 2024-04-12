using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI gravityText;
    public TextMeshProUGUI gameTimeText;
    private float gameTime;


    
void Start()
    {
        gameTime = 0f;
    }
    void Update()
    {
        UpdateGameTimeText();
        
        gravityText.text = "Gravity : " + Physics.gravity.y.ToString("F2") + " m/s²";
    }
 void UpdateGameTimeText()
    {
        gameTime += Time.deltaTime;
        gameTimeText.text = $"{Mathf.Floor(gameTime / 60):00}:{Mathf.Floor(gameTime % 60):00}";
    }
   
   
}
