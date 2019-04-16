using System;
using UIKit;

namespace MovieList
{
    public class Application
    {
        static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception e)
            {
                var r = e.Message;
            }
        }
    }
}
