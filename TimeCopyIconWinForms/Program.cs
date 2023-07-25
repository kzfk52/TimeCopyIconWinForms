namespace TimeCopyIconWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string mutexName = "TimeCopyIconWinForm";

            Mutex mutex = new Mutex(true, mutexName, out var createdNew);
            if (createdNew)
            {
                try
                {
                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new Form1());

                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
                    Application.Run(new Form1());
                }
                finally
                {
                    mutex.ReleaseMutex();
                    mutex.Close();
                }
            }
            else
            {
                MessageBox.Show(@"ä˘Ç…ãNìÆÇµÇƒÇ¢Ç‹Ç∑ÅB");
                mutex.Close();
            }



        }
    }
}