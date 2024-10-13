using LinqBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL_File
{
    public interface IFileProcessor
    {
        public void LeesTraining(string fileName);
    }
}
