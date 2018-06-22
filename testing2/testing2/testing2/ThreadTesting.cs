using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingCSharp
{

    class Thread1
    {
        private static object thisLock = new object();
        public void ThreadPlay()
        {
            ThreadStart childref1 = new ThreadStart(Thread1.CallToThread);
            Thread childThread1 = new Thread(childref1);
            childThread1.Start();

            ThreadStart childref2 = new ThreadStart(Thread2.CallToThread);
            Thread childThread2 = new Thread(childref2);
            childThread2.Start();

            Console.ReadKey();
        }
        public static void CallToThread()
        {
            Console.WriteLine("Thread1 starts");

            try
            {
                lock (thisLock)
                {
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(".//test.txt");                    
                    using (StreamWriter stream = File.AppendText(".//test.txt"))
                    {
                        Console.WriteLine("Thread1 starts writing to file...");
                        for (int i = 0; i < 10000; i++)
                        {
                            stream.WriteLine("thread1 " + i);
                        }
                        stream.Close();
                        Console.WriteLine("Thread1 starts writing to file...");
                    }
                }
            }
            catch(Exception ex)
            {

            }
            Console.WriteLine("Thread1 finished");            
        }

        private void testValue()
        {
            while (true)
            {
                Program.TestValue = 7;
                Console.WriteLine("Thread1 value = " + Program.TestValue);
            }
            //the thread is paused for 5000 milliseconds

           int sleepfor = 5000;
           Console.WriteLine("Thread Paused for {0} seconds", sleepfor / 1000);
           Thread.Sleep(sleepfor);
            Console.WriteLine("Thread resumes");
        }
    }
    class Thread2
    {
        private static object thisLock = new object();
        private static bool NeedToWrite = true;
        public static void CallToThread()
        {
            Console.WriteLine("Thread2 starts");
            while (NeedToWrite)
            {
                try
                {
                    lock (thisLock)
                    {
                        //System.IO.StreamWriter file = new System.IO.StreamWriter(".//test.txt");
                        Console.WriteLine("Thread2 starts writing to file...");
                        using (StreamWriter stream = File.AppendText(".//test.txt"))
                        {
                            for (int i = 0; i < 10000; i++)
                            {
                                stream.WriteLine("thread2 " + i);
                                //Console.WriteLine("thread2 writes " + i);
                            }
                            stream.Close();
                        }
                        NeedToWrite = false;
                    }   
                }
                catch(IOException ioEx)
                {

                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("Thread2 finished");
        }

        private void testValue()
        {
            while (true)
            {
                Program.TestValue = 10;
                Console.WriteLine("Thread2 value = " + Program.TestValue);
            }
           //the thread is paused for 5000 milliseconds

           int sleepfor = 5000;
           Console.WriteLine("Thread Paused for {0} seconds", sleepfor / 1000);
           Thread.Sleep(sleepfor);
           Console.WriteLine("Thread resumes");
        }
    }

}
