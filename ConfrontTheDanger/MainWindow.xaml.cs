using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ConfrontTheDanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer player = new SoundPlayer();
        private MainPage firstPage = new MainPage();
        private bool songOnOff = false;

        public MainWindow()
        {
            InitializeComponent();

            string musicFileName = "music_for_playing.wav"; // Replace with your actual file name
            string musicFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sounds", musicFileName);
            ChangeWindow();

            if (File.Exists(musicFilePath))
            {
                player.SoundLocation = musicFilePath;
                player.Load();
                player.PlayLooping();
            }
            else
            {
                MessageBox.Show(musicFilePath);
            }
            firstPage.startGame += FirstPage_startGame;
            songOnOff = true;
        }

        private void FirstPage_startGame(object? sender, EventArgs e)
        {
            MessageBox.Show("It's work!");
            /*делаем страницу с уровнями*/
        }

        private void ChangeWindow()
        {
            firstPage.Height = PagesArea.Height;
            firstPage.Width = PagesArea.Width;
            PagesArea.Content = firstPage;
        }

        private void Exit_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void SoundOn_Off_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            string newImagePath;
            if (!songOnOff)
            {
                player.PlayLooping();
                newImagePath = "pack://application:,,,/sound.png";
                songOnOff = true;
            }
            else
            {
                newImagePath = "pack://application:,,,/mute.png";
                player.Stop();
                songOnOff = false;
            }

            SoundOnOff.Source = new BitmapImage(new Uri(newImagePath));
        }

        private void Event_OnMouseMove(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }
        
        private void Event_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}