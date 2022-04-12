using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.Dto
{
    public class FolderFilterDto
    {
        public int FilesCount { get; set; }=0;
        public double TotalSize { get; set; } = 0;
    }
}
