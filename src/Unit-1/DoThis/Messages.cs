namespace WinTail;

static class Messages
{
    #region Neutral/system messages

    /// <summary>
    /// Marker class to continue processing.
    /// </summary>
    public class ContinueProcessing;

    #endregion

    #region Success messages

    /// <summary>
    /// Base class for signalling that user input was valid.
    /// </summary>
    public class InputSuccess
    {
        public InputSuccess(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }

    #endregion

    #region Error messages

    /// <summary>
    /// Base class for signalling that user input was invalid.
    /// </summary>
    public class InputError
    {
        public InputError(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }

    /// <summary>
    /// User provided blank input.
    /// </summary>
    public class NullInputError(string reason) : InputError(reason);

    /// <summary>
    /// User provided invalid input (currently, input w/ odd # chars)
    /// </summary>
    public class ValidationError(string reason) : InputError(reason);

    #endregion
}
