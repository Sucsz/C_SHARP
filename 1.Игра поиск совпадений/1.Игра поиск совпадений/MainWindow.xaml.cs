using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace _1.Игра_поиск_совпадений
{
    using System.Windows.Threading;
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text += " - Play again?";
            }
        }

        private void SetUpGame()
        {
            // Создать список из восьми пар эмодзи
            List<string> animalEmoji = new List<string>()
            {
                "🦔","🦔",
                "🐀","🐀",
                "🐰","🐰",
                "🐅","🐅",
                "🦘","🦘",
                "🐸","🐸",
                "🐨","🐨",
                "🦜","🦜"
            };
            // Создать новый генератор случайных чисел
            Random random = new Random();
            // Для каждого обхекта с типом TextBlock
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    // с помощью генератора случайных чисел выбираем индекс эмоджи из списка
                    int index = random.Next(animalEmoji.Count);
                    // находим этот эмоджи по индексу
                    string nextEmoji = animalEmoji[index];
                    // заменяем текст в блоке TextBlock изображением эмоджи
                    textBlock.Text = nextEmoji;
                    // удаляем эмоджи из списка во избежание повторного использования генератором
                    animalEmoji.RemoveAt(index);
                }
            }
            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound= 0;
        }
        // Последний выбранный TextBlock
        TextBlock lastTextBlockClicked;
        // Искать совпадение или нет(была ли выбрана картинка ранее)
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // текущий TextBlock
            TextBlock textBlock = sender as TextBlock;
            if (!findingMatch)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
