using System.Collections.Concurrent;
using Lesson_8;
//
// for (int i = 0; i < 10; i++)
// {
//     Thread.Sleep(700);
//     Console.WriteLine(i);
// }
//
// Thread currentThread = Thread.CurrentThread;
//
//
// Console.WriteLine($"Name thread: {currentThread.Name}");
// currentThread.Name = "Method Main";
// Console.WriteLine($"Name thread: {currentThread.Name}");
//
//
// Console.WriteLine($"Running thread or not: {currentThread.IsAlive}");
// Console.WriteLine($"Id thread: {currentThread.ManagedThreadId}");
// Console.WriteLine($"Priority thread: {currentThread.Priority}");
// Console.WriteLine($"Status thread: {currentThread.ThreadState}");


// Dictionary<string, string> dic = new Dictionary<string, string>();
//
// var dic2 = new ConcurrentDictionary<string, string>();
//
// dic2.TryAdd("1", "Value1");
//
// var user = new User() { Balance = 100 };
//
//
// var task1 = Task.Run(() => user.Withdraw(45));
//
// var task2 = Task.Run(() => user.Withdraw(45));
//
// var task3 = Task.Run(() => user.Withdraw(45));
//
// var task4 = Task.Run(() => user.Withdraw(45));
//
// Task.WaitAll(task1, task2, task3, task4);
// Console.WriteLine(user.Balance);

//Concurrency Main 1
//Semaphor Main 4
//Mutex Main 3
//Lock Main 2


//Concurrency 


// ConcurrentDictionary<string, int> dict = new();
//
// Parallel.For(0, 1000, i =>
// {
//     dict.AddOrUpdate("apple", 1,(key, oldValue) => oldValue + 1);
// });
//
// Console.WriteLine($"Mean: {dict["apple"]}"); 
//


//Lock 

// int x = 0;
//
// Lock _lockObj = new();
//
// for (int i = 1; i < 6; i++)
// {
//     Thread myThread = new(Print);
//     myThread.Name = $"Thread_{i}";
//     myThread.Start();
// }

//
// void Print()
// {
//     _lockObj.Enter();
//     try
//     {
//         x = 1;
//         for (int i = 0; i < 5; i++)
//         {
//             Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
//             x++;
//             Thread.Sleep(100);
//         }
//     }
//     
//     finally
//     {
//         _lockObj.Exit();
//     }
// }


// void Print()
// {
//     using (_lockObj.EnterScope())
//     {
//         x = 1;
//         for (int i = 0; i < 5; i++)
//         {
//             Console.WriteLine($"{Thread.CurrentThread.Name}: {x++}");
//             x++;
//             Thread.Sleep(100);
//         }
//     }
// }


// Mutex

// int x = 0;
// Mutex mutexObj = new();
//
//
// for (int i = 0; i < 6; i++)
// {
//     Thread myThread = new(Print);
//     myThread.Name = $"Thread {i}";
//     myThread.Start();
// }
//
// void Print()
// {
//     mutexObj.WaitOne();
//     x = 1;
//     for (int i = 0; i < 6; i++)
//     {
//         Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//         x++;
//         Thread.Sleep(100);
//     }
//
//     mutexObj.ReleaseMutex();
// }


//Semaphora

for (int i = 0; i < 6; i++)
{
    Reader reader = new Reader(i);
}

class Reader
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread _thread;
    int count = 3;

    public Reader(int i)
    {
        _thread = new Thread(Read);
        _thread.Name = $"Reader: {i}";
        _thread.Start();
    }


    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} enter the library");

            Console.WriteLine($"{Thread.CurrentThread.Name} read");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} leave library");

            sem.Release();

            count--;
            Thread.Sleep(1000);
        }
    }
}