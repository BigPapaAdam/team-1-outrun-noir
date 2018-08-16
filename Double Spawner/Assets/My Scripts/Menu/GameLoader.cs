using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.Video;
/**********************************************************
/Code that is commented out allows for the use of dropdown/
/instead of buttons for changing the keybindings          /
**********************************************************/

public class GameLoader : MonoBehaviour
{
    public GameObject SoundManager;
    public GameObject Menu;

    public static GameLoader GameInstance = null;

    public Toggle FullscreenToggle;
    public Dropdown ResolutionDropdown;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Resolution[] Resolutions;
    public AudioSource MusicSource;
    public AudioSource EngineSource;
    public AudioSource SFXSource;
    public AudioClip[] SFX01;
    public AudioClip SFX02;
    public AudioClip SFX03;
    public Button UpButton;
    public Button DownButton;
    public Dropdown ShootDropdown;
    public Button ContinueButton;
    public Button OptionsButton;
    public Button QuitButton;
    public VideoPlayer Videoplayer;
    public VideoClip[] Cutscenes;
    public AudioClip[] CutsceneAudio;
    //public Button ShootButton;
    //public Dropdown UpDropdown;
    //public Dropdown DownDropdown;
    public Text ScoreText;
    public Text HighScoreText;
    public Canvas WindowSize;
    public KeyCode CharacterMoveUp;
    public KeyCode CharacterMoveDown;
    public KeyCode CharacterShoot;
    private KeyCode NewKey;
    private string ButtonText;
    public int SceneNumber = 1;
    public int Score = 0;
    public int HighScore = 0;

    private bool IsButtonPressed = false;

    Event KeyEvent;

    private string[] Codes;

    private GameManager Gamemanager;

    private void Awake()
    {
        if (GameInstance == null)
        {
            GameInstance = this;
        }

        if (GameInstance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Gamemanager = new GameManager();

        SoundManager = GameObject.Find("SoundManager");
        MusicSource = SoundManager.transform.GetChild(0).GetComponent<AudioSource>();
        SFXSource = SoundManager.transform.GetChild(1).GetComponent<AudioSource>();
        EngineSource = SoundManager.transform.GetChild(2).GetComponent<AudioSource>();

        MusicSource.clip = SFX01[0];

        FullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        ResolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChanged(); });
        //UpDropdown.onValueChanged.AddListener(delegate { OnUpKeyChanged(); });
        //DownDropdown.onValueChanged.AddListener(delegate { OnDownKeyChanged(); });
        ShootDropdown.onValueChanged.AddListener(delegate { OnShootKeyChanged(); });
        SFXSlider.onValueChanged.AddListener(delegate { OnSFXSliderChange(); });
        MusicSlider.onValueChanged.AddListener(delegate { OnMusicSliderChange(); });
        ResolutionDropdown.ClearOptions();
        //UpDropdown.ClearOptions();
        //DownDropdown.ClearOptions();
        ShootDropdown.ClearOptions();

        Resolutions = Screen.resolutions;

        if(Resolutions != null)
        {
            foreach (Resolution resolution in Resolutions)
            {
                ResolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            }
        }
        else
        {
            WindowSize.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            WindowSize.GetComponent<CanvasScaler>().screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            WindowSize.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            WindowSize.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
        }

        Codes = Enum.GetNames(typeof(KeyCode));

        foreach (string code in Codes)
        {
            //UpDropdown.options.Add(new Dropdown.OptionData(code));
            //DownDropdown.options.Add(new Dropdown.OptionData(code));
            ShootDropdown.options.Add(new Dropdown.OptionData(code));
        }

        LoadSettings();

        MusicSource.volume = MusicSlider.value;
        SFXSource.volume = SFXSlider.value;
    }

    private void Start()
    {
        MusicSource.volume = MusicSlider.value = Gamemanager.Musicvolume;
        SFXSource.volume = SFXSlider.value = Gamemanager.SFXvolume;
        MusicSource.Play();

    }

    public void OnFullScreenToggle()
    {
        Gamemanager.FullScreen = Screen.fullScreen = FullscreenToggle.isOn;
        OnResolutionChanged();
    }

    public void OnMusicSliderChange()
    {
        MusicSource.volume = Gamemanager.Musicvolume = MusicSlider.value;
        GetComponent<AudioSource>().volume = MusicSource.volume;

    }

    public void OnSFXSliderChange()
    {
        SFXSource.volume = Gamemanager.SFXvolume = SFXSlider.value;
        EngineSource.volume = Gamemanager.SFXVolume = SFXSlider.value;
    }

    //public void OnUpKeyChanged()
    //{
    //    Gamemanager.UpKey = UpDropdown.options[UpDropdown.value].text;
    //    CharacterMoveUp = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.UpKey, true);
    //}

    //public void OnDownKeyChanged()
    //{
    //    Gamemanager.DownKey = DownDropdown.options[DownDropdown.value].text;
    //    CharacterMoveDown = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.DownKey, true);
    //}

    public void OnShootKeyChanged()
    {
        Gamemanager.FireKey = ShootDropdown.options[ShootDropdown.value].text;
        CharacterShoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.FireKey, true);
    }

    public void OnResolutionChanged()
    {
        Screen.SetResolution(Resolutions[ResolutionDropdown.value].width, Resolutions[ResolutionDropdown.value].height, Gamemanager.FullScreen);
        Gamemanager.Resolutionindex = ResolutionDropdown.value;
        ResolutionDropdown.RefreshShownValue();

        if (!FullscreenToggle.isOn)
        {
            WindowSize.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Resolutions[ResolutionDropdown.value].width, Resolutions[ResolutionDropdown.value].height);
        }
    }

    public void Play()
    {
        SceneNumber -= 1;
        Videoplayer.clip = Cutscenes[SceneNumber];
        GetComponent<AudioSource>().clip = CutsceneAudio[SceneNumber];
        GetComponent<AudioSource>().Play();
        MusicSource.clip = CutsceneAudio[SceneNumber];
        MusicSource.Play();

        if (SceneNumber < 3)
        {
            SceneNumber += 1;

            WindowSize.gameObject.SetActive(false);

            if(SceneNumber != 1 && SceneNumber < 3)
            {
                GameObject.Find("EGO Spawner Positioner").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                GameObject.Find("EGO Total Spawner").gameObject.SetActive(false);
                GameObject.Find("EGO Road Paver").gameObject.SetActive(false);
                GameObject.Find("EGO Enviro Paver").gameObject.SetActive(false);

                GameObject[] Roads = GameObject.FindGameObjectsWithTag("Road");

                foreach(GameObject Road in Roads)
                {
                   GameObject.Destroy(Road);
                }

                GameObject[] Environments = GameObject.FindGameObjectsWithTag("Environment");

                foreach (GameObject Environment in Environments)
                {
                    GameObject.Destroy(Environment);
                }
            }

            Videoplayer.enabled = true;
            MusicSource.Stop();

            Videoplayer.Play();

            Videoplayer.loopPointReached += EndReached;
        }
        else
        {
            SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
        }
    }

    void EndReached(VideoPlayer videoplayer)
    {
        SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Save()
    {
        Gamemanager.HighScore = HighScore;

        string jsondata = JsonUtility.ToJson(Gamemanager, true);

        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsondata);

        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void OnUpButtonClick()
    {
        UpButton.transform.GetChild(0).GetComponent<Text>().text = "Please enter a new key";
        ButtonText = "up";

        if (IsButtonPressed == false)
        {
            StartCoroutine(GetNewKey());
        }
    }

    public void OnDownButtonClick()
    {
        DownButton.transform.GetChild(0).GetComponent<Text>().text = "Please enter a new key";
        ButtonText = "down";

        if (IsButtonPressed == false)
        {
            StartCoroutine(GetNewKey());
        }
    }

    //public void ShootButtonClick()
    //{
    //    ShootButton.transform.GetChild(0).GetComponent<Text>().text = "Please enter a new key";
    //    ButtonText = "shoot";

    //    if (IsButtonPressed == false)
    //    {
    //        StartCoroutine(GetNewKey());
    //    }
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                if (!ContinueButton.gameObject.activeSelf && !Menu.activeSelf)
                {
                    Time.timeScale = 0;
                    ContinueButton.gameObject.SetActive(true);
                    OptionsButton.gameObject.SetActive(true);
                    QuitButton.gameObject.SetActive(true);
                    //Menu.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    ContinueButton.gameObject.SetActive(false);
                    OptionsButton.gameObject.SetActive(false);
                    QuitButton.gameObject.SetActive(false);
                    Menu.SetActive(false);
                    //Menu.SetActive(false);
                }
            }
        }
    }

    public void OnInGameMenuClick()
    {
        Time.timeScale = 0;
        ContinueButton.gameObject.SetActive(true);
        OptionsButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }

    public void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        ContinueButton.gameObject.SetActive(false);
        OptionsButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
    }

    public void OnOptionsButtonClick()
    {
        Menu.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        SceneNumber = 0;
        SceneManager.LoadScene(SceneNumber, LoadSceneMode.Single);
        SceneNumber = 1;
    }

    private void OnGUI()
    {
        KeyEvent = Event.current;

        if (KeyEvent.isKey && IsButtonPressed == true)
        {
            NewKey = KeyEvent.keyCode;
            IsButtonPressed = false;
        }
    }

    IEnumerator WaitForKey()
    {
        while (!KeyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator GetNewKey()
    {
        IsButtonPressed = true;
        yield return WaitForKey();

        switch (ButtonText)
        {
            case "up":
                CharacterMoveUp = NewKey;
                Gamemanager.UpKey = NewKey.ToString();
                UpButton.transform.GetChild(0).GetComponent<Text>().text = NewKey.ToString();
                StopCoroutine(GetNewKey());
                break;

            case "down":
                CharacterMoveDown = NewKey;
                Gamemanager.DownKey = NewKey.ToString();
                DownButton.transform.GetChild(0).GetComponent<Text>().text = NewKey.ToString();
                StopCoroutine(GetNewKey());
                break;

                //case "shoot":
                //    CharacterShoot = NewKey;
                //    Gamemanager.FireKey = NewKey.ToString();
                //    ShootButton.transform.GetChild(0).GetComponent<Text>().text = NewKey.ToString();
                //    StopCoroutine(GetNewKey());
                //    break;
        }
    }

    public void MouseOver()
    {
        if (Gamemanager.SFXvolume > 0.0f)
        {
            SFXSource.clip = SFX02;
            SFXSource.Play();
        }
    }

    public void MouseClick()
    {
        if (Gamemanager.SFXvolume > 0.0f)
        {
            SFXSource.clip = SFX03;
            SFXSource.Play();
        }
    }

    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json"))
        {
            Gamemanager = JsonUtility.FromJson<GameManager>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

            MusicSource.volume = MusicSlider.value = Gamemanager.Musicvolume;
            SFXSource.volume = SFXSlider.value = Gamemanager.SFXvolume;

            CharacterMoveUp = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.UpKey, true);
            UpButton.transform.GetChild(0).GetComponent<Text>().text = Gamemanager.UpKey;

            CharacterMoveDown = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.DownKey, true);
            DownButton.transform.GetChild(0).GetComponent<Text>().text = Gamemanager.DownKey;

            CharacterShoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), Gamemanager.FireKey, true);

            //ShootButton.transform.GetChild(0).GetComponent<Text>().text = Gamemanager.FireKey;
            ShootDropdown.options[ShootDropdown.value].text = Gamemanager.FireKey;

            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                HighScoreText = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Text>();
                ScoreText = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Text>();
                HighScore = Gamemanager.HighScore;
                HighScoreText.text = "High Score: " + Gamemanager.HighScore.ToString();
            }
        }
        else
        {
            Gamemanager.ResolutionIndex = Screen.currentResolution.width;
            Gamemanager.FullScreen = FullscreenToggle.isOn;
            Gamemanager.MusicVolume = MusicSlider.value = 0.5f;
            Gamemanager.SFXVolume = SFXSlider.value = 0.5f;
            Gamemanager.UpKey = CharacterMoveUp.ToString();
            Gamemanager.DownKey = CharacterMoveDown.ToString();
            Gamemanager.FireKey = CharacterShoot.ToString();
            Gamemanager.HighScore = 0;

            int i = 0;
            while(Gamemanager.ResolutionIndex != Resolutions[i].width)
            {
                i++;
            }

            Gamemanager.ResolutionIndex = i;
            ResolutionDropdown.value = i;

            string jsondata = JsonUtility.ToJson(Gamemanager, true);

            File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsondata);
        }

        Screen.fullScreen = FullscreenToggle.isOn = Gamemanager.FullScreen;
        ResolutionDropdown.value = Gamemanager.Resolutionindex;

        ResolutionDropdown.RefreshShownValue();
    }
}