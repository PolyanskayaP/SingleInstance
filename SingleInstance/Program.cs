// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Mutex oneMutex = null;
        const String MutexName = "RUNMEONCE";
        try //пытаемся открыть мьютекс
        {
            oneMutex = Mutex.OpenExisting(MutexName);
        }
        catch(WaitHandleCannotBeOpenedException)
        {
            //определяем, сущ ли мьютекс с таким именем
        }
        // Создаем его, если он не существует 
        if (oneMutex == null)
        {
            oneMutex = new Mutex(true, MutexName);
        }
        else
        {
            // Закрываем Mutex и выходим из приложения,
            // так как разрешается запуск только одного его экземпляра
            oneMutex.Close();
            return;
        }
    }
}