using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLib
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false,ElementName="config")]
    public partial class Config
    {

        private configFirstpart firstpartField;

        private configSecondpart secondpartField;

        /// <remarks/>
        public configFirstpart firstpart
        {
            get
            {
                return this.firstpartField;
            }
            set
            {
                this.firstpartField = value;
            }
        }

        /// <remarks/>
        public configSecondpart secondpart
        {
            get
            {
                return this.secondpartField;
            }
            set
            {
                this.secondpartField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configFirstpart
    {

        private header headerField;

        private content contentField;

        /// <remarks/>
        public header header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

       
        public content content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class header
    {

        private string firstlineField;

        /// <remarks/>
        public string firstline
        {
            get
            {
                return this.firstlineField;
            }
            set
            {
                this.firstlineField = value;
            }
        }

        public int index { get; set; }

        public int dateIndex { get; set; }
        public int line2Index { get; set; }
        public int line3Index { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class content
    {

        private string startField;

        private string separatorField;

        private string columnsField;

        /// <remarks/>
        public string start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        public int index { get; set; }

        /// <remarks/>
        public string separator
        {
            get
            {
                return this.separatorField;
            }
            set
            {
                this.separatorField = value;
            }
        }

        /// <remarks/>
        public string columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        public int lastIndex { get; set; }

    }

    public class footer
    {
        public string separator { get; set; }
        public int index1 { get; set; }
        public int index2 { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configSecondpart
    {

        private header headerField;

        private content contentField;

        /// <remarks/>
        public header header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public content content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        public footer footer { get; set; }
    }

}
