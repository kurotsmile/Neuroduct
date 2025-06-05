using UnityEngine;
using View.Control;
using View.Items;

public class Game_Handle : MonoBehaviour
{
    [Header("Main Object")]
    public Carrot.Carrot carrot;
    public GameObject HomePanel;
    public GameObject PlayPanel;

    [Header("Game Objects")]
    public ScrollView view;
    public ButtonScript ObjBtnBackHome;
    public AudioSource audioBkMusic;

    void Start()
    {
        this.carrot.Load_Carrot();
        this.HomePanel.SetActive(true);
        this.PlayPanel.SetActive(false);
        this.ObjBtnBackHome.ButtonPressed += OnBtn_Back_Home;
        this.carrot.game.load_bk_music(this.audioBkMusic);
    }

    public void OnBtn_Game_Start()
    {
        this.carrot.play_sound_click();
        this.HomePanel.SetActive(false);
        this.PlayPanel.SetActive(true);
        this.view.On_Start_Game();
    }

    private void OnBtn_Back_Home(ButtonType buttonType)
    {
        if (buttonType == ButtonType.Home)
        {
            this.carrot.play_sound_click();
            this.HomePanel.SetActive(true);
            this.PlayPanel.SetActive(false);
            this.view.On_Pause_Game();
        }
    }

    public void OnBtn_Game_Setting()
    {
        this.carrot.Create_Setting();
    }

    public void OnBtn_Game_Exit()
    {
        Application.Quit();
    }

    public void OnBtn_Share()
    {
        this.carrot.show_share();
    }

    public void OnBtn_Rate()
    {
        this.carrot.show_rate();
    }
}
