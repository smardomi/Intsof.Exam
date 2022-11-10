﻿using System.Text.RegularExpressions;

namespace Intsoft.Exam.Application.Validators
{
    /// <summary>
    /// IranCodes Utils
    /// </summary>
    public static class IranCodesUtils
    {
        private static readonly Regex _matchIranianMobileNumber1 = new Regex(@"^(((98)|(\+98)|(0098)|0)(9){1}[0-9]{9})+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);
        private static readonly Regex _matchIranianMobileNumber2 = new Regex(@"^(9){1}[0-9]{9}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);
        private static readonly Regex _matchIranianPhoneNumber = new Regex("^[0][1-9]{2}[2-9][0-9]{7}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);
        private static readonly Regex _matchIranianPostalCode = new Regex(@"\b(?!(\d)\1{3})[13-9]{4}[1346-9][013-9]{5}\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: RegexUtils.MatchTimeout);

        /// <summary>
        /// Validate Iranian mobile number
        /// </summary>
        public static bool IsValidIranianMobileNumber(this string? mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                return false;
            }

            //mobileNumber = mobileNumber.ToEnglishNumbers();
            return _matchIranianMobileNumber1.IsMatch(mobileNumber) || _matchIranianMobileNumber2.IsMatch(mobileNumber);
        }

        /// <summary>
        /// Validate Iranian phone number
        /// </summary>
        public static bool IsValidIranianPhoneNumber(this string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }

            //phoneNumber = phoneNumber.ToEnglishNumbers();
            return !string.IsNullOrWhiteSpace(phoneNumber) && _matchIranianPhoneNumber.IsMatch(phoneNumber);
        }

        /// <summary>
        /// Validate Iranian postal code
        /// </summary>
        public static bool IsValidIranianPostalCode(this string? postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return false;
            }

            //postalCode = postalCode.ToEnglishNumbers();
            return !string.IsNullOrWhiteSpace(postalCode) && _matchIranianPostalCode.IsMatch(postalCode);
        }
    }
}