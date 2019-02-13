﻿namespace ToastNotifications.Share
{
    public interface IToastNotificationRepresenter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        void ShowTwoLines(TwoLinesToastNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        void ShowRichInterableNotification(TwoLinesToastNotificationInfo notification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        void Dismiss(string tag);
    }
}
