namespace ToastNotifications.Share.ActionButtons
{
    public enum ActivationType
    {
        Foreground,
        Background,
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ActivationTypeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activationType"></param>
        /// <returns></returns>
        public static string ToStringOne(this ActivationType activationType)
        {
            switch (activationType)
            {
                default:
                case ActivationType.Foreground:
                    return "foreground";
                case ActivationType.Background:
                    return "background";
            };
        }
    }
}
