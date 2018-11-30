using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bean
{
    public class CTrigramme
    {
        public int tri_id;
        public string tri_trigramme;

        public CTrigramme()
        {
        }

        public CTrigramme(string tri_trigramme)
        {
            this.tri_trigramme = tri_trigramme;
        }

        public CTrigramme(int tri_id, string tri_trigramme)
        {
            this.tri_id = tri_id;
            this.tri_trigramme = tri_trigramme;
        }
    }
}
