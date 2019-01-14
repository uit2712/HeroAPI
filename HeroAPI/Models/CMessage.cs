using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroAPI.Models
{
    public class CMessage
    {
        public CMessage(string message)
        {
            Message = message;
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    _message = string.Empty;
                else _message = value;
            }
        }
    }
}