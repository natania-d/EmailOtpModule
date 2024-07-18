namespace EmailOtpModule
{
    public class StatusCodes
    {
        #region Email Status COdes
        public const string EmailOk = "STATUS_EMAIL_OK";
        public const string EmailFail = "STATUS_EMAIL_FAIL";
        public const string EmailInvalid = "STATUS_EMAIL_INVALID";
        #endregion

        #region OTP Status COdes
        public const string OtpOk = "STATUS_OTP_OK";
        public const string OtpFail = "STATUS_OTP_FAIL";
        public const string OtpTimeout = "STATUS_OTP_TIMEOUT";
        #endregion
    }
}
