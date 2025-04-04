using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MVVM.Services
{
    public interface IMyService
    {
        string GetMessage();
    }

    public class MyService : IMyService
    {
        public string GetMessage() => "Hello from MyService!";
    }

    public class FaizService : IMyService
    {
        public string GetMessage() => "Henlo From Faiz";
    }

}
