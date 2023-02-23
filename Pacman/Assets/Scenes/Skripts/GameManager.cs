using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //Jadro
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform balls;

    // UI Text
    public Text GameOverTxt;
    public Text NewGameTxt;
    public Text ScoreTxt;
    public Text LivesTxt;
    public Text BestScoreTxt;
    public Text PressButtonTxt;
    public SpriteRenderer GameOverField;
    public Image image;
    
    // Audio
    public AudioSource music;

    public int score {get; set;}
    public int lives {get; set;}

    void Start()
    {
        music = GetComponent<AudioSource>();
        pacman.gameObject.SetActive(false);

        NewGame();
    }

    private void Update() {
        //Pokud pacman ztratil všechny své životy, hra začíná znovu.
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
        }
    }
    private void NewGame()
    {
        music.Stop();
        NewGameTxt.enabled = true;
        PressButtonTxt.enabled = true;
        GameOverField.enabled = true;

        GameOverTxt.enabled = false;
        ScoreTxt.enabled = false;
        LivesTxt.enabled = false;
        BestScoreTxt.enabled = false;
        image.enabled = false;


        if (Input.anyKeyDown){
            SetScore(0);
            SetLives(3);

            NewGameTxt.enabled = false;
            PressButtonTxt.enabled = false;
            GameOverField.enabled = false;
            GameOverTxt.enabled = false;

            ScoreTxt.enabled = false;
            LivesTxt.enabled = true;
            BestScoreTxt.enabled = false;
            image.enabled = true;

            NewRound();
            music.Play();
        }
    }
    
    private void SetScore(int score)
    {
        this.score = score;
        ScoreTxt.text = "score: " + score.ToString();
        ScoreTxt.enabled = true;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        LivesTxt.text = "x" + lives.ToString();
        LivesTxt.enabled = true;
    }

    private void NewRound()
    {
        //Activace polohy.
        foreach (Transform ball in this.balls){
            ball.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        //Restovani polohy.
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].ResetState();           
        }

        this.pacman.ResetState();
    }

    private void GameOver()
    {
        //DeActivace pokud konec hry.
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false);           
        }

        this.pacman.gameObject.SetActive(false);

        NewGameTxt.enabled = false;
        PressButtonTxt.enabled = true;
        GameOverField.enabled = true;
        GameOverTxt.enabled = true;

        ScoreTxt.enabled = false;
        LivesTxt.enabled = false;
        BestScoreTxt.text = score.ToString();
        BestScoreTxt.enabled = true;
        image.enabled = false;

        music.Stop();
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);

        ghost.ResetState();

    }

    public void PacmanEaten()
    {
        //Pokud snedli pacmana a existuje dost mnozstvi zivotu, pak hra zacina znovu.
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            ResetState();
        } 
        else 
        {
            GameOver();
        }
    }

    public void BallsEat(Ball ball)
    {
        ball.gameObject.SetActive(false);
        SetScore(this.score + ball.points);
        if (! ThereAreBallsOnTheField()){
            this.pacman.gameObject.SetActive(false);

            NewRound();
        }
    }

    public void BigBallsEat(BigBall ball)
    {
        ball.gameObject.SetActive(false);
        SetScore(this.score + ball.points);
        
        if (! ThereAreBallsOnTheField()){
            this.pacman.gameObject.SetActive(false);

            NewRound();
        }

        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].frightened.Enable();        
        }
    }

    private bool ThereAreBallsOnTheField(){
        // Pokud jsou na hřišti koule, pak true

        foreach (Transform ball in this.balls)
        {
            if (ball.gameObject.activeSelf) {
                return true;
            }
        }
        return false;
    }

}
