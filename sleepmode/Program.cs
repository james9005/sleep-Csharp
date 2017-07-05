using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices; 
using System.Threading;

namespace sleepmode {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("System Started Properly. ");
      Console.WriteLine(".................................\n");
      if(args.Length ==1) {
        int time;
      
        Int32.TryParse(args[0], out time);
        if(time >0) {
          Console.WriteLine("setting the time for {0} minutes. Press CTRL + C to cancel.",time);
          Thread.Sleep(time * 60 * 1000);
          Console.WriteLine("[{0}] : Sending the computer to sleep! ", DateTime.Now.ToString());
          SetSuspendState(false, true, true);
          Console.ReadKey();
        }
        else {
          Console.WriteLine("incorrect parse. try again.");
        }
      }
      else {
        Console.WriteLine("defaulting to 30 minutes.");
        Thread.Sleep(30 * 60 * 1000);

        Console.WriteLine("[{0}] : Sending the computer to sleep! ", DateTime.Now.ToString());
        SetSuspendState(false, true, true);
        Console.ReadKey();
      }
    }
    [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
  }
}
