using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bean
{
    public class CExigence
    {
        public int exi_id;
        public string exi_description;
        public int exi_type;
        public int exi_projet;

        public CExigence()
        {
        }

        public CExigence(string exi_description, int exi_type, int exi_projet)
        {
            this.exi_description = exi_description;
            this.exi_type = exi_type;
            this.exi_projet = exi_projet;
        }

        public CExigence(int exi_id, string exi_description, int exi_type, int exi_projet)
        {
            this.exi_id = exi_id;
            this.exi_description = exi_description;
            this.exi_type = exi_type;
            this.exi_projet = exi_projet;
        }
    }
}
