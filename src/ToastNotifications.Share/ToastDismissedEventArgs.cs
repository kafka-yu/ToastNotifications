using System;

namespace ToastNotifications.Share
{
    public class ToastDismissedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public ToastDismissalReason Reason { get; set; }
    }
}
