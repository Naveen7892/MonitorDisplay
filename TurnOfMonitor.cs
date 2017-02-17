using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Threading;

namespace MonitorDisplay {
   /// <summary>
   /// Turns off monitor
   /// </summary>
   class TurnOfMonitor {

      static int i = 5;
      static Timer t;

      static void Main (string[] args) {
         
         t = new Timer(UserWindow,null,0,1000);
         Console.ReadKey ();
      }

      static void UserWindow(Object o) {
         if(i <= 0) {
            //Using the system pre-defined MSDN constants that can be used by the SendMessage() function
            int WM_SYSCOMMAND = 0x0112;
            int SC_MONITORPOWER = 0xF170;
            SendMessage (0xFFFF, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
            t.Dispose ();
            return;
         }
         Console.WriteLine ("Monitor will be turned off in: " + i + " seconds!(press any key to cancel)");
         i--;
         // Force a garbage collection to occur for this demo.
         GC.Collect ();
      }

      /// <summary>
      /// puts the monitor to off state
      /// </summary>
      /// <param name="hWnd"></param>
      /// <param name="hMsg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport ("user32.dll")]
      private static extern int SendMessage (int hWnd, int hMsg, int wParam, int lParam);
   }
}
