using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp
{
    public class DelegatesEvents
    {
        #region Basic Event Handlers
        public class Car
        {
            // This delegate works in conjunction with the
            // Car’s events.
            public delegate void CarEngineHandler(string msg);
            
            // This car can send these events.
            public event CarEngineHandler Exploded;
            public event CarEngineHandler AboutToBlow;

            /* Events Under the Hood
             * When the compiler processes the C# event keyword, it generates two hidden methods, one having an add_ prefix and the other having 
             * a remove_ prefix. Each prefix is followed by the name of the C# event. For example, the Exploded event results in two hidden methods 
             * named add_Exploded() and remove_Exploded() . If you were to check out the CIL instructions behind add_AboutToBlow(), you would find 
             * a call to the Delegate.Combine() method
             */

            // Class constructors.
            public Car() { }
            public Car(string name, int maxSp, int currSp)
            {
                CurrentSpeed = currSp;
                MaxSpeed = maxSp;
                PetName = name;
            }

            // Internal state data.
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; } = 100;
            public string PetName { get; set; }
            // Is the car alive or dead?
            private bool carIsDead;

            public void Accelerate(int delta)
            {
                // If the car is dead, fire Exploded event.
                if (carIsDead)
                {
                    if (Exploded != null)
                        Exploded("Sorry, this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;

                    // Almost dead?
                    if (10 == MaxSpeed - CurrentSpeed
                      && AboutToBlow != null)
                    {
                        AboutToBlow("Careful buddy! Gonna blow!");
                    }

                    // Still OK!
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }

            public static void CarAboutToBlow(string msg)
            { Console.WriteLine(msg); }

            public static void CarIsAlmostDoomed(string msg)
            { Console.WriteLine("=> Critical Message from Car: {0}", msg); }

            public static void CarExploded(string msg)
            { Console.WriteLine(msg); }

            /* Cleaning Up Event Invocation Using the C# 6.0 Null-Conditional Operator
             * In the current example, you most likely noticed that before you fired an event to any listener, you made sure to check for null.
             * This is important given that if nobody is listening for your event but you fire it anyway, you will receive a null reference exception 
             * at runtime. While important, you might agree it is a bit clunky to make numerous conditional checks against null.

             * Thankfully, with the current release of C#, you can leverage the null conditional operator (?) which essentially performs this sort of check 
             * automatically. Be aware, when using this new simplified syntax, you must manually call the Invoke() method of the underlying delegate
             */

            public void AccelerateEventsWithNullCheck(int delta)
            {
                // If the car is dead, fire Exploded event.
                if (carIsDead)
                {
                    Exploded?.Invoke("Sorry, this car is dead...");
                }
                else
                {
                    CurrentSpeed += delta;

                    // Almost dead?
                    if (10 == MaxSpeed - CurrentSpeed)
                    {
                        AboutToBlow?.Invoke("Careful buddy!  Gonna blow!");
                    }

                    // Still OK!
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }

            public static void TestDelegateEvents()
            {
                Console.WriteLine("***** Fun with Events *****\n");
                Car c1 = new Car("SlugBug", 100, 10);

                // Register event handlers.
                c1.AboutToBlow += CarIsAlmostDoomed;
                c1.AboutToBlow += CarAboutToBlow;
                c1.Exploded += CarExploded;

                Console.WriteLine("***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                    c1.Accelerate(20);

                // Remove CarExploded method
                // from invocation list.
                c1.Exploded -= CarExploded;

                Console.WriteLine("\n***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                    c1.Accelerate(20);
                Console.ReadLine();
            }                     
        }
        #endregion

        #region Working with EventArgs
        public class CarEventArgs : EventArgs
        {
            // Internal state data.
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; } = 100;
            public string PetName { get; set; }
            // Is the car alive or dead?
            private bool carIsDead;

            public readonly string msg;
            public CarEventArgs(string message)
            {
                msg = message;
            }
            public CarEventArgs() { }
            public CarEventArgs(string name, int maxSp, int currSp)
            {
                CurrentSpeed = currSp;
                MaxSpeed = maxSp;
                PetName = name;
            }

            public delegate void CarEngineHandler(object sender, CarEventArgs e);

            // This car can send these events.
            public event CarEngineHandler Exploded;
            public event CarEngineHandler AboutToBlow;

            public static void CarAboutToBlow(object sender, CarEventArgs e)
            {
                // Just to be safe, perform a
                // runtime check before casting.
                if (sender is Car)
                {
                    Car c = (Car)sender;
                    Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
                }
            }

            public static void CarExploded(object sender, CarEventArgs e)
            {
                Console.WriteLine("{0} says: {1}", sender, e.msg);
            }

            public void Accelerate(int delta)
            {
                // If the car is dead, fire Exploded event.
                if (carIsDead)
                {
                    Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
                }
                else
                {
                    CurrentSpeed += delta;

                    // Almost dead?
                    if (10 == MaxSpeed - CurrentSpeed
                      && AboutToBlow != null)
                    {
                        AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                    }

                    // Still OK!
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }

            public static void TestEventArgs()
            {
                Console.WriteLine("***** Fun with Events *****\n");
                CarEventArgs c1 = new CarEventArgs("SlugBug", 100, 10);

                // Register event handlers.                    
                c1.AboutToBlow += CarAboutToBlow;
                c1.Exploded += CarExploded;

                Console.WriteLine("***** Speeding up *****");
                for (int i = 0; i < 6; i++)
                    c1.Accelerate(20);
                Console.ReadLine();
            }
        }
        #endregion
    }
}
