using System;
using System.IO;
using System.Threading;

namespace FileApplication {
    class Program {
        private static string userData { get; set; }
        private static Object readLock = new Object();
        private static Object writeLock = new Object();
        private static void SetData() {
            // Read and show each line from the file
            string line = "";

            lock(Program.readLock) {
                using (StreamReader sr = new StreamReader("data.txt")) {
                    while ((line = sr.ReadLine()) != null) {
                        Program.userData = line;
                    }
                }
            }
        }
        private static void Set() {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(1);

            var timer = new Timer((e) =>
                { Program.SetData(); }, null, startTimeSpan, periodTimeSpan);
        }
        private static void DisplayData() {
            // Displaying the 'userData' onto console
            lock(Program.writeLock) {
                Console.WriteLine(Program.userData);
            }
        }
        private static void Display() {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(3);

            var timer = new Timer((e) =>
                { Program.DisplayData(); }, null, startTimeSpan, periodTimeSpan);
        }
        static void Main(string[] args) {

            Program.Set();
            Program.Display();

            Console.ReadKey();
        }
    }
}