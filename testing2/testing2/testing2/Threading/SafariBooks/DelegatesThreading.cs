﻿using System;
using System.Threading;

namespace TestingCSharp.Threading
{
    public class DelegatesThreading
    {
        public delegate int BinaryOp(int x, int y);

        public static void TestDelegateSync()
        {
            Console.WriteLine("***** Sync Delegate Review *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("TestDelegateSync() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() in a synchronous manner.
            BinaryOp b = new BinaryOp(Add);

            // Could also write b.Invoke(10, 10);
            int answer = b(10, 10);

            // These lines will not execute until
            // the Add() method has completed.
            Console.WriteLine("Doing more work in TestDelegateSync()!");
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        public static void TestDelegateAsync()
        {
            Console.WriteLine("***** Async Delegate Invocation *****");

            // Print out the ID of the executing thread.
            Console.WriteLine("TestDelegateAsync() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Invoke Add() on a secondary thread.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            // Do other work on primary thread...
            Console.WriteLine("Doing more work in TestDelegateAsync()!");

            // Obtain the result of the Add()
            // method when ready.
            int answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
              Thread.CurrentThread.ManagedThreadId);

            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
