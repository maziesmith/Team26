namespace UpgradeYourself.Common
{
    class UserNotification
    {
        public void NotifyUser(string strMessage, NotifyType type)
        {
            switch (type)
            {
                // Use the status message style.
                case NotifyType.StatusMessage:
                    //AnswerStatusCorrect.Style = Resources["StatusStyle"] as Style;
                    break;
                // Use the error message style.
                case NotifyType.ErrorMessage:
                   // AnswerStatusWrong.Style = Resources["ErrorStyle"] as Style;
                    break;
            }
            //StatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            //if (StatusBlock.Text != String.Empty)
            //{
            //    StatusBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //}
            //else
            //{
            //    StatusBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            //}
        }

        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage,
        };
    }
}
