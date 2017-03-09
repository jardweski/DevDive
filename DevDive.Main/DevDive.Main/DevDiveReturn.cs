using System.Collections.Generic;

namespace DevDive.Main
{
    public class DevDiveReturn
    {
        public DevDiveReturn()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public bool Sucess => Errors.Count <= 0;

        public string Message { get; set; }
    }
}