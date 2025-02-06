using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Bussiness.CommonModels
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrade { get; set; }

        public ErrorResponse(Exception ex, string error)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrade = error;
        }
    }
}
