using System;
namespace ToastNotifications.Share
{
    public class ToastActivatedEventArgs : EventArgs
    {
        public string Tag { get; set; }

        public string Arguments { get; set; }

        public string Group { get; set; }
    }
}
