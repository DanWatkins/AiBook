using Eto.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atgp.Chapter3
{
    public class Path
    {
        public List<Point> Parts { get; }

        public Path(List<Point> parts)
        {
            if (parts == null)
                throw new ArgumentNullException(nameof(parts));

            Parts = parts;
        }
    }
}