﻿using System;
using System.IO;

class Program
{
    static string NormalizeText(string text)
    {
        string normalizedText = "";
        bool capitalize = true;

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (currentChar == '.' || currentChar == '?' || currentChar == '!')
            {
                capitalize = true; // Устанавливаем флаг заглавной буквы после знака пунктуации
            }
            else if (Char.IsWhiteSpace(currentChar))
            {
                // Пропускаем лишние пробелы
                if (normalizedText.Length > 0 && !Char.IsWhiteSpace(normalizedText[normalizedText.Length - 1]))
                {
                    normalizedText += currentChar;
                }
            }
            else
            {
                // Приводим символы к заглавным или строчным буквам в зависимости от флага
                if (capitalize)
                {
                    currentChar = Char.ToUpper(currentChar);
                    capitalize = false;
                }
                else
                {
                    currentChar = Char.ToLower(currentChar);
                }

                normalizedText += currentChar;
            }
        }

        return normalizedText;
    }

    static void Main(string[] args)
    {
        string filePath = @"example.txt";

        // Создаем файл и записываем в него некое содержимое
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("это пример текста. он содержит некоторые знаки пунктуации??? и много пробелов. ");

        }

        // Читаем содержимое файла
        string text = File.ReadAllText(filePath);

        // Нормализуем текст
        string normalizedText = NormalizeText(text);

        // Выводим нормализованный текст
        Console.WriteLine(normalizedText);
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("это пример текста. он содержит некоторые знаки пунктуации??? и много пробелов. ");
            writer.WriteLine(normalizedText);

        }


    }
}