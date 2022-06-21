using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_App.ResponseModels
{
  public class CreateResponseModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
  }
}
