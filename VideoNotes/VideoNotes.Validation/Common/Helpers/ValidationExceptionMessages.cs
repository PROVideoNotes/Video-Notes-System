namespace VideoNotes.Validation.Common.Helpers
{
    using System;
    using System.Text;

    public static class ValidationExceptionMessages
    {
        public static string UserNotAuthenticated(string userId, string action, string actionParametarId)
        {
            return string.Format("User with id {0} is not authenticated to {1} with id={2}", userId, action, actionParametarId);
        }

        public static string SearchKeyWordsIncorrect(string keywords)
        {
            return string.Format("You must enter correct keywords that you want to search for! {0} keywords are incorrect!", keywords);
        }
    }
}
