using System;

namespace Shom.ISO8211
{
    public abstract class DataDescriptiveRecordField : Field
    {
        public DataStructureCode DataStructureCode;
        public DataTypeCode DataTypeCode;
        public char FieldTerminatorPrintableGraphic;
        public char[] TruncatedEscapeSequence = new char[3];
        public char UnitTerminatorPrintableGraphic;

        public DataDescriptiveRecordField(string tag, byte[] fieldControls) : base(tag)
        {
            int val = Int32.Parse(((char) fieldControls[0]).ToString());
            DataStructureCode = (DataStructureCode) val;

            val = Int32.Parse(((char) fieldControls[1]).ToString());
            DataTypeCode = (DataTypeCode) val;

            if (DataTypeCode == DataTypeCode.BitStringIncludingBinaryForms && (char) fieldControls[2] != '0' &&
                (char) fieldControls[3] != '0')
            {
                throw new NotImplementedException("Processing Auxillary controls in Field Controls");
            }

            FieldTerminatorPrintableGraphic = (char) fieldControls[4];
            UnitTerminatorPrintableGraphic = (char) fieldControls[5];

            if (fieldControls.Length > 6)
            {
                TruncatedEscapeSequence[0] = (char) fieldControls[6];
                TruncatedEscapeSequence[1] = (char) fieldControls[7];
                TruncatedEscapeSequence[2] = (char) fieldControls[8];
            }
        }

        public override string ToString()
        {
            return base.ToString() + "FieldControls:" + DataStructureCode.ToString() + ":" + DataTypeCode.ToString() + ":" +
                   FieldTerminatorPrintableGraphic + ":" + UnitTerminatorPrintableGraphic + ":" +
                   new string(TruncatedEscapeSequence) + Environment.NewLine;
        }
    }
}