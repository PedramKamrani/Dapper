using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper1.ViewModel;

namespace Dapper1.Services
{
   public interface Iwin
   {
       Task<List<WinViewModel>> GetAll();
        Task Add(CreateViewModel model);
   }
}
