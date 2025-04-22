using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private PlayerController playerController;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        button.onClick.AddListener(playerController.StartGameSequence);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
