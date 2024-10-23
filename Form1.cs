using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        private string currentWord;
        private List<char> guessedLetters = new List<char>();
        private int remainingGuesses;
        private Timer timer;
        private int timeLeft = 90;
        private Label[] wordLabels;
        private int score = 0; // Puan 0'dan başlıyor
        private Label lblScoreboard;

        public Form1()
        {
            InitializeComponent();
            InitScoreboard(); // Scoreboard'ı başlat
            LoadNewWord();
            InitTimer();
        }

        private void InitScoreboard()
        {
            lblScoreboard = new Label
            {
                Location = new Point(this.ClientSize.Width - 150, 10), // Sağ üst köşe
                Size = new Size(140, 25),
                Text = "Puan: 0",
                Font = new Font("Arial", 14),
                TextAlign = ContentAlignment.TopRight
            };
            this.Controls.Add(lblScoreboard);
        }

        private void UpdateScoreboard()
        {
            lblScoreboard.Text = $"Puan: {score}";
        }

        private void LoadNewWord()
        {
            try
            {
                var words = File.ReadAllLines("kelimeler.txt");
                if (words.Length == 0)
                {
                    throw new Exception("Kelimeler dosyası boş.");
                }

                var random = new Random();
                currentWord = words[random.Next(words.Length)].ToUpper(); // Tüm harfler büyük olacak
                guessedLetters.Clear();
                remainingGuesses = 6; // Adamın 6 parçası için
                InitializeWordLabels();
                this.Invalidate(); // Yeni kelime ile adamı yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void InitializeWordLabels()
        {
            if (wordLabels != null)
            {
                foreach (var label in wordLabels)
                {
                    this.Controls.Remove(label);
                }
            }

            wordLabels = new Label[currentWord.Length];
            for (int i = 0; i < currentWord.Length; i++)
            {
                wordLabels[i] = new Label
                {
                    Location = new Point(250 + (i * 30), 50),
                    Size = new Size(20, 25),
                    Text = "_", // Hiçbir harfi başlangıçta göstermiyoruz
                    Font = new Font("Arial", 14)
                };
                this.Controls.Add(wordLabels[i]);
            }
        }

        private void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                lblTime.Text = $"Kalan Süre:{timeLeft} ";
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Süre doldu!");
                LoadNewWord();
                timeLeft = 90;
                timer.Start();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtGuess.Text.Length > 0)
            {
                char guessedLetter = char.ToUpper(txtGuess.Text[0]); // Büyük harf olarak tahmin ediliyor
                ProcessGuess(guessedLetter);
                txtGuess.Text = ""; // txtGuess'i temizleyelim
            }
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            string userGuess = txtFullGuess.Text.ToUpper(); // Tam tahmini büyük harfe çeviriyoruz
            if (userGuess.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
            {
                int guessedLettersCount = guessedLetters.Count;
                int totalWordScore = currentWord.Length * 10;
                int correctGuessedScore = guessedLettersCount * 10;
                score += totalWordScore - correctGuessedScore; // Puanlama sistemi uygulanıyor

                MessageBox.Show($"Doğru tahmin! Toplam puan: {score}");
            }
            else
            {
                int unguessedLetters = currentWord.Length - guessedLetters.Count;
                score -= unguessedLetters * 10; // Yanlış tahmin için ceza
                MessageBox.Show($"Yanlış tahmin! -{unguessedLetters * 10} puan. Toplam puan: {score}");
            }
            UpdateScoreboard();
            LoadNewWord();
            txtFullGuess.Text = ""; // Tam tahmin girişini temizle
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Oyun bitti! Toplam puanınız: {score}");
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtGuess.Text.Length > 0)
                {
                    char guessedLetter = char.ToUpper(txtGuess.Text[0]); // Büyük harf olarak tahmin ediliyor
                    ProcessGuess(guessedLetter);
                    txtGuess.Text = ""; // txtGuess'i temizleyelim
                }
                else if (txtFullGuess.Text.Length > 0)
                {
                    string userGuess = txtFullGuess.Text.ToUpper(); // Tam tahmini büyük harfe çeviriyoruz
                    if (userGuess.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
                    {
                        int guessedLettersCount = guessedLetters.Count;
                        int totalWordScore = currentWord.Length * 10;
                        int correctGuessedScore = guessedLettersCount * 10;
                        score += totalWordScore - correctGuessedScore; // Puanlama sistemi

                        MessageBox.Show($"Doğru tahmin! Toplam puan: {score}");
                    }
                    else
                    {
                        int unguessedLetters = currentWord.Length - guessedLetters.Count;
                        score -= unguessedLetters * 10; // Yanlış tahmin için ceza
                        MessageBox.Show($"Yanlış tahmin! -{unguessedLetters * 10} puan. Toplam puan: {score}");
                    }
                    UpdateScoreboard();
                    LoadNewWord();
                    txtFullGuess.Text = ""; // Tam tahmin girişini temizle
                }
            }
        }

        private void ProcessGuess(char guessedLetter)
        {
            if (!guessedLetters.Contains(guessedLetter))
            {
                guessedLetters.Add(guessedLetter); // Harfi listeye ekle

                if (currentWord.Contains(guessedLetter))
                {
                    UpdateWordLabels();
                }
                else
                {
                    remainingGuesses--;
                    score -= 10; // Yanlış harf tahmini için 10 puan eksiltiliyor
                    MessageBox.Show($"Yanlış harf! -10 puan. Toplam puan: {score}");
                    this.Invalidate(); // Adamın çizimini güncelle
                }
            }

            if (remainingGuesses <= 0)
            {
                MessageBox.Show($"Oyun bitti! Kelime: {currentWord}. Toplam puan: {score}");
                LoadNewWord();
            }
            UpdateScoreboard();
        }

        private void UpdateWordLabels()
        {
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (guessedLetters.Contains(currentWord[i]))
                {
                    wordLabels[i].Text = currentWord[i].ToString(); // Doğru tahmin edilen harfi ekrana yaz
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawHangman(e.Graphics);
        }

        private void DrawHangman(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);

            // Stand
            g.DrawLine(pen, 50, 300, 200, 300); // Base
            g.DrawLine(pen, 125, 300, 125, 100); // Vertical pole
            g.DrawLine(pen, 125, 100, 200, 100); // Horizontal pole
            g.DrawLine(pen, 200, 100, 200, 150); // Rope

            // Adamın parçaları
            if (remainingGuesses <= 5) // Head
                g.DrawEllipse(pen, 175, 150, 50, 50);
            if (remainingGuesses <= 4) // Body
                g.DrawLine(pen, 200, 200, 200, 250);
            if (remainingGuesses <= 3) // Left arm
                g.DrawLine(pen, 200, 220, 170, 190);
            if (remainingGuesses <= 2) // Right arm
                g.DrawLine(pen, 200, 220, 230, 190);
            if (remainingGuesses <= 1) // Left leg
                g.DrawLine(pen, 200, 250, 170, 280);
            if (remainingGuesses <= 0) // Right leg
                g.DrawLine(pen, 200, 250, 230, 280);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
