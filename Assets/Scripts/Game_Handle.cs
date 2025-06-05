using Core.Game;
using UnityEngine;
using UnityEngine.UI;
using View.Control;
using View.Items;

public class Game_Handle : MonoBehaviour
{
    [Header("Main Object")]
    public Carrot.Carrot carrot;
    public IronSourceAds ads;
    public ScrollView view;
    public ButtonScript ObjBtnBackHome;
    public AudioSource audioBkMusic;

    [Header("UI")]
    public Text txt_tip_home;
    public GameObject HomePanel;
    public GameObject PlayPanel;

    void Start()
    {
        this.carrot.Load_Carrot(CheckExitApp);
        this.ads.On_Load();
        this.carrot.act_buy_ads_success=this.ads.RemoveAds;
        this.carrot.game.act_click_watch_ads_in_music_bk=this.ads.ShowRewardedVideo;
        this.ads.onRewardedSuccess=this.carrot.game.OnRewardedSuccess;
        this.HomePanel.SetActive(true);
        this.PlayPanel.SetActive(false);
        this.ObjBtnBackHome.ButtonPressed += OnBtn_Back_Home;
        this.carrot.game.load_bk_music(this.audioBkMusic);
        this.Update_Ui();
    }

    private void CheckExitApp()
    {
        if (this.PlayPanel.activeInHierarchy)
        {
            this.OnBtn_Back_Home(ButtonType.Home);
            this.carrot.set_no_check_exit_app();
        }
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
            this.ads.show_ads_Interstitial();
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
