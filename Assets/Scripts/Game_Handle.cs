using Core.Game;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("UI")]
    public Text txt_tip_home;

    void Start()
    {
        this.carrot.Load_Carrot();
        this.HomePanel.SetActive(true);
        this.PlayPanel.SetActive(false);
        this.ObjBtnBackHome.ButtonPressed += OnBtn_Back_Home;
        this.carrot.game.load_bk_music(this.audioBkMusic);
        this.Update_Ui();
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
            this.Update_Ui();
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

    public void OnBtn_Other_App()
    {
        this.carrot.show_list_carrot_app();
    }

    public void OnBtn_ShowListLevel()
    {
        this.view._navigation.OnShowHelp();
    }

    private void Update_Ui()
    {
        this.txt_tip_home.text = "You are playing level " + this.view.GetLevelCur() + "/" + Levels.LevelCount + " of the level";
    }

    public void OnBtn_BK_music()
    {
        this.carrot.game.show_list_music_game();
    }

    public void OnRemoveAds()
    {
        this.carrot.buy_inapp_removeads();
    }
}
