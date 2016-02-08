namespace VideoNotes.Validation.Common
{
    using System;

    public class ValidationResult
    {
        public ValidationResult(string key, string message) 
        {
            this.Key = key;
            this.Message = message;
        }

        public string Key { get; private set; }

        public string Message { get; private set; }
    }
}
