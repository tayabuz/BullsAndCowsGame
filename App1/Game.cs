using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{

    class Game
    {
        public Game()
        {
            randomNumber = getRandomNumber();
        }
        public const int NUMBER_OF_ITEMS = 4;//число позиции в случайном числе
        public List<int> randomNumber;//коллекция, где хранится случайное число 
        public int bullsCount = 0; //счетчик быков
        public int cowsCount = 0; //счетчик коров
        //public static List<int> userAnswer = new List<int>();//коллекция, где хранится число, которое ввел игрок

        public static List<int> getRandomNumber()//генерирует случайное число
        {
            Random rand = new Random();
            var randomNumber = new List<int>();
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                bool isDublicateFound = false;
                while (isDublicateFound == false)
                {
                    var tempRandomNumber = rand.Next(1, 6);
                    randomNumber.Contains(tempRandomNumber);
                    if (randomNumber.Contains(tempRandomNumber) == false)
                    {
                        randomNumber.Add(tempRandomNumber);
                        isDublicateFound = true;
                    }
                }
            }
            return randomNumber;
        }

        public List<int> getUserAnswer(string userAnswerString)//принимает ответ игрока и преобразует его в числовой массив
        {
            var userAnswer = new List<int>();
            bool userAnswerInvalid = true;
            int userAnswerOneNumber;
            while (userAnswerInvalid == true)
            {
                try
                {
                    if (userAnswerString.Length == NUMBER_OF_ITEMS)
                    {

                        for (int j = 0; j < userAnswerString.Length; j++)
                        {
                            userAnswerOneNumber = (int)Char.GetNumericValue(userAnswerString[j]);
                            if ((userAnswerOneNumber < 7) && (userAnswerOneNumber > 0))
                            {
                                userAnswer.Add(userAnswerOneNumber);
                                userAnswerInvalid = false;
                                continue;
                            }

                        }
                    }
                    else
                    { }

                }

                catch (FormatException)
                {

                }

            }
            return userAnswer;
        }

        public bool checkUserAnswer(List<int> userAnswer)//проверяет ответ игрока
        {
            bullsCount = 0;
            cowsCount = 0;
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                if (userAnswer.Contains(randomNumber[i]))
                {
                    if (userAnswer[i] == randomNumber[i]) { bullsCount++; }
                    else { cowsCount++; }
                }
            }

            if (bullsCount == 4)
            {
                return true;
            }
            return false;
        }
    }

}

