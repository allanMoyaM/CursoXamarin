using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    public class Request
    {
        public bool CheckStateChanLog { get; set; }

        public bool IsSuccessful { get; set; }

        public string OperationId { get; set; }

        public List<Error> Errors { get; set; }

        public bool ExpiredSession { get; set; }

        public Request()
        {
            Errors = new List<Error>();
        }
    }

    public class Error
    {
        public Error()
        {

        }

        public String Message { set; get; }
        public int Code { set; get; }
    }
}
