using System;
using System.IO;
using System.Threading;

namespace FileApplication {
    class Program {
        private string userData = null;
        private static void print() {
            // Read and show each line from the file
            string line = "";
            using (StreamReader sr = new StreamReader("data.txt")) {
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
        }
        private static void FetchData() {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(2);

            var timer = new Timer((e) =>
                { Program.print(); }, null, startTimeSpan, periodTimeSpan);
        }
        static void Main(string[] args) {
            ///ThreadStart childref = new ThreadStart(timerFunc);
            Program.FetchData();

            // ThreadStart fetchData = new ThreadStart(//fetch data function);
            // ThreadStart displayData = new ThreadStart(//display data function);

            ///Thread childThread = new Thread(childref);

            // Thread fetchThread = new Thread(fetchData);
            // Thread displayThread = new Thread(displayData);
            
            /// childThread.Start();

            // fetchThread.Start();
            //displayThread.Start();

            // Thread.Sleep(15 * 1000);
            Console.ReadKey();
        }
    }
}