using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Game game;
        public MainPage()
        {
            InitializeComponent();
            game = new Game();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tempString = outputBox.Text;
            if (checkOutput(tempString) == true)
            {
                var userAnswerOutput = game.getUserAnswer(outputBox.Text);
                bool isUserAnswerValid = game.checkUserAnswer(userAnswerOutput);

                if (isUserAnswerValid)
                {
                    informationViewer.Text += "\r\n" + "You win";
                }
                else
                {
                    informationViewer.Text += "\r\n" + outputBox.Text;
                    informationViewer.Text += "\r\n" + "The quantity of bulls is: " + game.bullsCount + "\r\n";
                    informationViewer.Text += "The quantity of cows is: " + game.cowsCount + "\r\n";
                }
                
            }
            outputBox.Text = "";
        }

        private void outputBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Button_Click(sender, new RoutedEventArgs());
                e.Handled = true;
            } 
        }

        private bool checkOutput(string userAnswerString)
        {
            bool userAnswerValid = true;
            int userAnswerOneNumber;
            try
            {
                if (userAnswerString.Length != Game.NUMBER_OF_ITEMS)
                {
                    userAnswerValid = false;
                }
                else
                {
                    for (int j = 0; j < userAnswerString.Length; j++)
                    {
                        userAnswerOneNumber = (int)Char.GetNumericValue(userAnswerString[j]);
                        if ((userAnswerOneNumber > 6) || (userAnswerOneNumber < 1))
                        {
                            userAnswerValid = false;
                            break;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                userAnswerValid = false;
            }
            return userAnswerValid;
        }
    }
}
