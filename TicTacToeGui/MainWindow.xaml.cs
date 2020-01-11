using System.Windows;
using System.Windows.Controls;
using TicTacToe;

namespace TicTacToeGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game GameInstance;
        Player PlayerX;
        Player PlayerO;

        uint Rounds = 0;

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            PlayerX = new Player("X");
            PlayerO = new Player("O");

            GameInstance = new Game(PlayerX, PlayerO);

            StartNewGame();
        }

        #endregion

        private void StartNewGame ()
        {
            GameInstance.Restart();
            ClearMap();
        }

        private void ClearMap ()
        {
            Button0_0.Content = "";
            Button1_0.Content = "";
            Button2_0.Content = "";
            Button0_1.Content = "";
            Button1_1.Content = "";
            Button2_1.Content = "";
            Button0_2.Content = "";
            Button1_2.Content = "";
            Button2_2.Content = "";

            XWinsText.Text = PlayerX.Score.ToString();
            OWinsText.Text = PlayerO.Score.ToString();
            RoundsText.Text = Rounds.ToString();
        }

        private void CheckIsEnd ()
        {
            if (!GameInstance.IsEnd)
                return;

            if (GameInstance.Winner == PlayerX)
            {
                MessageBox.Show("Wygrał gracz X", "Koniec", MessageBoxButton.OK);
                PlayerX.AddScore();
            }
            else if (GameInstance.Winner == PlayerO)
            {
                MessageBox.Show("Wygrał gracz O", "Koniec", MessageBoxButton.OK);
                PlayerO.AddScore();
            }
            else if (GameInstance.IsFull)
            {
                MessageBox.Show("Remis!", "Koniec", MessageBoxButton.OK);
            }
            Rounds++;
            StartNewGame();
        }

        private void MakeMove (short row, short col, Button button)
        {
            Board.BOARD_VALUE value = GameInstance.MakeMove(row, col);
            if (value == Board.BOARD_VALUE.X)
            {
                button.Content = "X";
            }
            else if (value == Board.BOARD_VALUE.O)
            {
                button.Content = "O";
            }
            ChangeTurn();
            CheckIsEnd();
        }

        private void ChangeTurn ()
        {
            if (GameInstance.CurrentPlayer == PlayerX)
                CurrentPlayerText.Text = "X";
            else
                CurrentPlayerText.Text = "O";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == Button0_0)
                MakeMove(0, 0, btn);
            else if (btn == Button1_0)
                MakeMove(0, 1, btn);
            else if (btn == Button2_0)
                MakeMove(0, 2, btn);
            else if (btn == Button0_1)
                MakeMove(1, 0, btn);
            else if (btn == Button1_1)
                MakeMove(1, 1, btn);
            else if (btn == Button2_1)
                MakeMove(1, 2, btn);
            else if (btn == Button0_2)
                MakeMove(2, 0, btn);
            else if (btn == Button1_2)
                MakeMove(2, 1, btn);
            else if (btn == Button2_2)
                MakeMove(2, 2, btn);
        }
    }
}
