using System;
using System.Diagnostics;

public class MessageObserver : IObservable
{
    // Method to update and display the notification message
    public void Update(string message)
    {
        // Create a new process
        using (Process process = new Process())
        {
            // Set the filename and arguments for the process
            process.StartInfo.FileName = "notify-send";
            process.StartInfo.Arguments = $"\"Notification\" \"{message}\"";

            try
            {
                // Start the process
                process.Start();

                // Wait for the process to exit
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Debug.WriteLine($"Error occurred while displaying notification: {ex.Message}");
            }
        }
    }
}