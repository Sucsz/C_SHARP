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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
    }
}
