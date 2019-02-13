namespace ToastNotifications.Share
{
    public class TwoLinesToastNotificationInfo : ToastNotificationInfo
    {
        /// <summary>
        /// 5 * 1000, Only supported in customized notification representer
        /// </summary>
        public int Duration { get; set; } = 5 * 1000;

        /// <summary>
        /// First line text
        /// </summary>
        public string FirstLineText { get; set; }

        /// <summary>
        /// Second line text
        /// </summary>
        public string SecondLineText { get; set; }
    }
}
