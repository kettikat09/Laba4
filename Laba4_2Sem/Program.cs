// Завдання 1. Створити об'єкт класу Текст, використовуючи класи Речення, Слово. Методи: доповнити текст, вивести на консоль текст, заголовок тексту.

using Newtonsoft.Json;
using System;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        Text t = new Text();
        t.AddTXT("Hello, I am Tommy.");
        t.AddTXT("What do you want to know about me?");
        t.ChangeTop("Intro");
        Console.WriteLine(t.ToString());
    }
}
public class Text
{
    public string Top;
    public Rechen[] rechen;
    public Text()
    {
        this.rechen = new Rechen[0];
    }
    public void AddTXT(string txt)
    {
        Rechen[] r = new Rechen[rechen.Length + 1];
        for (int i = 0; i < rechen.Length; i++)
        {
            r[i] = rechen[i];
        }
        r[rechen.Length] = new Rechen();
        r[rechen.Length].AddRechen(txt);
        rechen = r;
    }
    public void ChangeTop(string txt)
    {
        Top = txt;
    }
    public string ToString()
    {
        string a = Top + "\n";
        for (int i = 0; i < rechen.Length; i++)
        {
            a += rechen[i].ToString();
        }
        return a;
    }
}
public class Rechen
{
    public Slowo[] slowo;
    public Rechen()
    {
        this.slowo = new Slowo[0];
    }
    public void AddRechen(string txt)
    {
        string[] txt_m = txt.Split(' ');
        Slowo[] s = new Slowo[txt_m.Length];
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = new Slowo(txt_m[i]);
        }
        slowo = s;
    }

    public string ToString()
    {
        string a = "";
        for (int i = 0; i < slowo.Length; i++)
        {
            a += slowo[i].word + " ";
        }
        return a;
    }
}
public class Slowo
{
    public string word;
    public Slowo(string word)
    {
        this.word = word;
    }
}