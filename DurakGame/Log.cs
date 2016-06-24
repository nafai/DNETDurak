/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\Log.cs
 * Description: Contains logging functions that put messages into a string
 *              (which is read from the main form) and output to a file.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DurakGame
{
    class Log
    {
        #region Functions

        /// <summary>
        /// Logs information. Returns whether the log was successful or not.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Write(string message, bool isPublic)
        {
            try
            {
                // Declarations:
                // Get the current time and date.
                DateTime timestamp = DateTime.Now;
                
                // The string to be outputted to the log file/debug console
                string output = Convert.ToString(timestamp) + ": " + message + "\r\n";

                // Log the messege to the file stored in the Program variable:
                File.AppendAllText(Program.optionLogPath+@"\G4Durak.log", output);
                
                // Write to debug console as well
                Debug.WriteLine(output);

                if (isPublic)
                    Game.userMessageLog += message+"\r\n";

                return true;
            }
            catch (Exception ex)                                                        
            {
                // Audio alert
                Console.Beep();
                
                // Display a message box
                System.Windows.Forms.MessageBox.Show("ERROR: Unable to log,\"" + message + "\".\n\n" + ex);
                
                // Report failure
                return false;
            }
        }
        public static bool Write(string message)
        {
            return Write(message, false);
        }

        #endregion
    }
}
