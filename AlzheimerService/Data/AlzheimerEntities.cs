using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzheimerService.Data
{
    public partial class AlzheimerEntities
    {
        private static AlzheimerEntities _context;
        public static AlzheimerEntities GetContext()
        {
            if (_context == null)
                _context = new AlzheimerEntities();
            return _context;
        }
    }
}
