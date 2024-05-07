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

namespace lab1_var10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        public class Node
        {
            public string Term { get; set; }
            public string Explanation { get; set; }
            public Node Next { get; set; }
        }

        Node head;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(string term, string explanation)
        {
            var node = new Node { Term = term, Explanation = explanation };

            if (head == null)
            {
                head = node;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }

        private string Search(string term)
        {
            var current = head;
            while (current != null)
            {
                if (current.Term == term)
                {
                    return current.Explanation;
                }
                current = current.Next;
            }
            return "Term not found";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add(TermInput.Text, ExplanationInput.Text);
            TermInput.Clear();
            ExplanationInput.Clear();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Search(SearchInput.Text));
            SearchInput.Clear();
        }
    }
}