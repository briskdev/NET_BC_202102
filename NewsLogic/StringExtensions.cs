using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLogic
{
    /// <summary>
    /// Extension class should be STATIC
    /// </summary>
    public static class StringExtensions
    {
        // We're extending STRING class with a method:
        // - public bool IsPasswordOk(){ }
        public static bool IsPasswordOk(this string text)
        {
            // all validation to check if password is OK
            return !String.IsNullOrEmpty(text) && text.Length >= 6;
        }
    }
}
