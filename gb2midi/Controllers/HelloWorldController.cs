using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace gb2midi.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
    //public string Welcome(String name, int times=1)
    //{
    //    return HtmlEncoder.Default.Encode($"hello {name}, times var is: {times}");
    //    //return "This is the Welcome action method...";
    //}
}