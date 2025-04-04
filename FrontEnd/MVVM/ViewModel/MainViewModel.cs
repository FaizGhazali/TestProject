using FrontEnd.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MVVM.ViewModel
{
    public class MainViewModel
    {
        private readonly IMyService _myService;

        public string Message { get; }

        public MainViewModel(IMyService myService)
        {
            _myService = myService;
            Message = _myService.GetMessage();
        }
    }

}
