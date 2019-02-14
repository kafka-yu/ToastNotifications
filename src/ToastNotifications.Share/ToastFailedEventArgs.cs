using System;

namespace ToastNotifications.Share
{
    public class ToastFailedEventArgs : EventArgs
    {
        public Exception ErrorCode { get; set; }
    }
}
